    public class PartContext : DbContext {
        private static readonly string _ConnectionString = new NpgsqlConnectionStringBuilder {
            Host = "localhost",
            Port = 5432,
            Database = "postgres",
            Username = "postgres",
            Password = "password"
        }.ConnectionString;
        public readonly string Table;
        public readonly string Partition;
        public PartContext(string pMainTable, string pPartition) : base(
            new NpgsqlConnection() { ConnectionString = _ConnectionString },
            PartDbModelBuilder.Get(_ConnectionString, pPartition),
            true
        ) {
            Table = pMainTable;
            Partition = pPartition;
            Database.SetInitializer<PartContext>(null);
            /**
             * Disable database initialization so that the DbCachedModels are not kept internally in Entity
             * This causes high memory usage when having a lot of tables 
             * In EF 6.4.2 there was no way to 'manage' that Dictionary externally
             */
            try {
                var InternalContext = typeof(PartContext).BaseType.GetProperty("InternalContext", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(this, null);
                InternalContext.GetType().GetProperty("InitializerDisabled").SetValue(InternalContext, true);
            } catch(Exception) { }
        }
        public DbSet<MyPart> Parts { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
This provides the DbCachedModels:
I recommend adding some custom caching code etc, this is just from a sample
    class PartDbModelBuilder {
        public static DbCompiledModel Get(string pConnectionString, string pTable) {
            DbModelBuilder builder = new DbModelBuilder();
            builder.Entity<MyPart>().ToTable(pTable, "public");
            using (var connection = new NpgsqlConnection() { ConnectionString = pConnectionString }) {
                var obj = builder.Build(connection).Compile();
                return obj;
            }
        }
    }
This is the entity I used as a test:
    public class MyPart {
        public int id { get; set; }
        public string name { get; set; }
        public string value { get; set; }
    }
Class I used to run the test:
    class EFTest {
        public void Run(int tableCount) {
            int done = 0;
            Parallel.For(0, tableCount, new ParallelOptions { MaxDegreeOfParallelism = 5 }, (i) => {
                string id = i.ToString().PadLeft(5, '0');
                using (var context = new PartContext("mypart", "mypart_" + id)) {
                    var objResult = context.Parts.First();
                    Console.WriteLine(objResult.name);
                }
                done++;
                Console.WriteLine(done + " DONE");
            });
        }
    }
Table definition:
    CREATE TABLE IF NOT EXISTS mypart (
        id SERIAL,
        name text,
        value text
    ) partition by list (name);
    CREATE TABLE IF NOT EXISTS part partition of mypart_00000 for values in ('mypart00000');
    CREATE TABLE IF NOT EXISTS part partition of mypart_00001 for values in ('mypart00001');
    CREATE TABLE IF NOT EXISTS part partition of mypart_00002 for values in ('mypart00002');
    ...
Postgres 9:
    CREATE TABLE IF NOT EXISTS mypart (
        id SERIAL,
        name text,
        value text
    );
    CREATE TABLE IF NOT EXISTS ".$name."( CHECK ( name =  'mypart00000')) INHERITS (mypart);
    CREATE TABLE IF NOT EXISTS ".$name."( CHECK ( name =  'mypart00001')) INHERITS (mypart);
    CREATE TABLE IF NOT EXISTS ".$name."( CHECK ( name =  'mypart00002')) INHERITS (mypart);
    ...
