        [Test]
        public async Task TestAsync2()
        {
            using (var context = new TestDbContext())
            {
                Console.WriteLine("Thread Before Async/Await: " + Thread.CurrentThread.ManagedThreadId.ToString());
                var names = await context.Customers.Select(x => x.Name).ToListAsync();
                Console.WriteLine("Thread After Async/Await: " + Thread.CurrentThread.ManagedThreadId.ToString());
            }
        }
