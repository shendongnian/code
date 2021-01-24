        [Test]
        public void TestAsync3()
        {
            using (var context = new TestDbContext())
            {
                Console.WriteLine("Thread Before Async: " + Thread.CurrentThread.ManagedThreadId.ToString());
                var names = context.Customers.Select(x => x.Name).ToListAsync();
                Console.WriteLine("Thread After Async: " + Thread.CurrentThread.ManagedThreadId.ToString());
                var result = names.Result;
                Console.WriteLine("Thread After Result: " + Thread.CurrentThread.ManagedThreadId.ToString());
            }
        }
