    public sealed class MyConfiguration : 
       DbMigrationsConfiguration<MyContext>
    {
       public Configuration()
       {
          AutomaticMigrationsEnabled = true;
       }
    
       protected override void Seed( MyContext context )
       {
          //insert statements here
       }
    }
