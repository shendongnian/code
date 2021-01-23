    using System.Linq;
    using System.Data.Entity;
    namespace EFNestedProjection
    {
        // Entities
        public class ModelA
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public ModelB ModelB { get; set; }
        }
        public class ModelB
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public class ModelC
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public class ModelD
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        // Context
        public class MyContext : DbContext
        {
            public DbSet<ModelA> ModelSetA { get; set; }
            public DbSet<ModelB> ModelSetB { get; set; }
            public DbSet<ModelC> ModelSetC { get; set; }
            public DbSet<ModelD> ModelSetD { get; set; }
        }
        // ViewModels for projections, not entities
        public class MyModelA
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public MyModelB ModelB { get; set; }
            public MyModelC ModelC { get; set; }
            public MyModelD ModelD { get; set; }
        }
        public class MyModelB
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public class MyModelC
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public class MyModelD
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                // Create some entities in DB
                using (var ctx = new MyContext())
                {
                    var modelA = new ModelA { Name = "ModelA" };
                    var modelB = new ModelB { Name = "ModelB" };
                    var modelC = new ModelC { Name = "ModelC" };
                    var modelD = new ModelD { Name = "ModelD" };
                    modelA.ModelB = modelB;
                    ctx.ModelSetA.Add(modelA);
                    ctx.ModelSetB.Add(modelB);
                    ctx.ModelSetC.Add(modelC);
                    ctx.ModelSetD.Add(modelD);
                    ctx.SaveChanges();
                }
                // Run query
                using (var ctx = new MyContext())
                {
                    var result = (
                        from a in ctx.ModelSetA.Include("ModelB")
                        join c in ctx.ModelSetC on a.Id equals c.Id
                        join d in ctx.ModelSetD on a.Id equals d.Id
                        select new MyModelA()
                        {
                            Id = a.Id,
                            Name = a.Name,
                            ModelB = new MyModelB() {
                                Id = a.ModelB.Id, Name = a.ModelB.Name },
                            ModelC = new MyModelC() {
                                Id = c.Id, Name = c.Name },
                            ModelD = new MyModelD() {
                                Id = d.Id, Name = d.Name }
                        }).FirstOrDefault();
                    // No exception here
                }
            }
        }
    }
