// DbModelPatches.cs
public partial class newTable : IEntity
{
    public EntityState EntityState { get; set; }
}
public partial class oldTable : IEntity
{
    public EntityState EntityState { get; set; }
}
If default constructor is generate by `tt` you cannot replace it in partial file, but you can define another one, parametreized, and put all changes there.
public partial class myEntities : DbContext
{
    public myEntities(string name)
        : base("name={name}")
    {
        Configuration.LazyLoadingEnabled = false;
        Configuration.ProxyCreationEnabled = false;
    }
   // or static factory method:
   public static myEntities CreateContext() 
   {
      var res = new myEntities();
      res.Configuration.LazyLoadingEnabled = false;
      res.Configuration.ProxyCreationEnabled = false;
      return res;
   }
}
