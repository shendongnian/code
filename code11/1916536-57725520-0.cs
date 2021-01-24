    public sealed class MyConfiguration : 
       DbMigrationsConfiguration<at.loe.wkj.persistence.WkjContext>
    {
       public Configuration()
       {
          AutomaticMigrationsEnabled = true;
       }
    
       protected override void Seed( at.loe.wkj.persistence.WkjContext context )
       {
          //insert statements here
       }
    }
