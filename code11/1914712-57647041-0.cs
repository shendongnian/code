    using Xunit;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    namespace MyTestProject
    {
        public class DbContextTest
        {
            [Fact]
            public void ActualQuery()
            {
                var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>()
                    .UseNpgsql("Host=mypgsvr;Database=mydb;Username=myusr;Password=mypass");
                var SUT = new MyDbContext(optionsBuilder.Options);
                var firstRow = SUT.mytable.First();
                Assert.NotNull(firstRow);
            }
        }
    }
