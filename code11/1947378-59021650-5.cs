    class Program {
        static void Main(string[] args) {
            var p = PersonBuilder
                .Create()
                    .WithName("My Name")
                    .HavingJob(builder => builder
                        .WithCompanyName("First Company")
                        .WithSalary(100)
                    )
                    .HavingJob(builder => builder
                        .WithCompanyName("Second Company")
                        .WithSalary(200)
                    )
                .Build();
            Console.WriteLine(JsonConvert.SerializeObject(p));
        }
    }
