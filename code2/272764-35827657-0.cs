    using System.Data.Entity;
    [....]
    public partial class MyDBEntities {
      public void AddOrUpdate(MyDBEntities ctx, DbSet set, Object obj, long ID) {
          if (ID != 0) {
              set.Attach(obj);
              ctx.Entry(obj).State = EntityState.Modified;
          }
          else {
              set.Add(obj);
          }
      }
    [....]
