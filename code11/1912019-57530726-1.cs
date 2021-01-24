         public class CounterRepository
         {
             private readonly IMongoCollection<Counter> _countersCollection;
         
             public CounterRepository(IMongoCollection<Counter> countersCollection)
             {
                 _countersCollection = countersCollection ?? throw new ArgumentNullException(nameof(countersCollection));
             }
         
             public async Task<Counter> TryInsert(Counter counter)
             {
                 var policy = Policy.Handle<OptimisticConcurrencyException>()
                     .WaitAndRetryAsync(new[] {
                         TimeSpan.FromSeconds(1),
                         TimeSpan.FromSeconds(3),
                         TimeSpan.FromSeconds(7)
                     });
         
                 return await policy.ExecuteAsync(() => TryInsertInternal(counter));
             }
         
             private async Task<Counter> TryInsertInternal(Counter counter)
             {
                 var existingCounter = await _countersCollection.Find(c => c.Id == counter.Id).FirstOrDefaultAsync();
         
                 if (existingCounter == null)
                     return await InsertInternal(counter);
                 return await IncreaseVersion(existingCounter);
             }
             
             private async Task<Counter> InsertInternal(Counter counter)
             {
                 try
                 {
                     counter.Version = 1;
                     await _countersCollection.InsertOneAsync(counter);
                     return counter;
                 }
                 // if smbd insert value after you called Find(returns null at that moment)
                 // you try to insert entity with the same id and exception will be thrown
                 // you try to handle it by marking with optimistic concurrency and retry policy
                 // wait some time and execute the method and Find returns not null now so that
                 // you will not insert new record but just increase the version
                 catch (MongoException)
                 {
                     throw new OptimisticConcurrencyException();
                 }
             }
             private async Task<Counter> IncreaseVersion(Counter existing)
             {
                 long versionSnapshot = existing.Version;
                 long nextVersion = versionSnapshot + 1;
         
                 var updatedCounter = await _countersCollection.FindOneAndUpdateAsync(
                     c => c.Id == existing.Id && c.Version == versionSnapshot,
                     new UpdateDefinitionBuilder<Counter>().Set(c => c.Version, nextVersion));
         
                 // it can be null if smbd increased existing version that you fetched from db
                 // so you data is now the newest one and you throw OptimisticConcurrencyException
                 if (updatedCounter == null)
                     throw new OptimisticConcurrencyException();
         
                 return updatedCounter;
             }
         }
