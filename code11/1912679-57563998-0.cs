    class Program
    {
        static void Main(string[] args)
        {
            var options = new DbContextOptionsBuilder<DtSkmContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            using (var context = new DtSkmContext(options))
            {
                var service = new DtSkmService(context);
                service.Add(3, 7);
                context.SaveChanges();
            }
            using (var context = new DtSkmContext(options))
            {
                Assert.That(context.DtSkm.Count(), Is.EqualTo(1));
                var service = new DtSkmService(context);
                var result = service.Find(3, 7);
                Assert.That(result, Is.Not.Null);
            }
        }
    }
