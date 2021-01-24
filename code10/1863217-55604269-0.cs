        [Test]
        public async Task TestAsync()
        {
            using (var context = new TestDbContext())
            {
                Console.WriteLine("Thread Before Async: " + Thread.CurrentThread.ManagedThreadId.ToString());
                var names = context.Customers.Select(x => x.Name).ToListAsync();
                Console.WriteLine("Thread Before Await: " + Thread.CurrentThread.ManagedThreadId.ToString());
                var result = await names;
                Console.WriteLine("Thread After Await: " + Thread.CurrentThread.ManagedThreadId.ToString());
            }
        }
