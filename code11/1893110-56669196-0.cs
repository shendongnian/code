    public class Teacher
    {
        public void Insert(Teacher entity)
        {
             //Initialize DB context here
             context.Teachers.Add(entity);
             context.SaveChanges();
        }
       public void Update(Teacher entity)
       {
             //Initialize DB context here
             context.Teachers.Attach(entity);
             context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
             context.SaveChanges();
       }
    }
