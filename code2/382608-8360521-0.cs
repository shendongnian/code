    public class MyObjectModel : MyEFObject
    {
        public void Save(int? id, MyObjectModel model)
        {
           var data = new Entities();
           MyEFObject foo;
           if(id.HasValue)
           {  
               foo = data.MyEFObjects.Where(e => e.ID.Equals(id.Value)).Single();
           }
           else
           {
               foo = new MyEFObject();
           }
           foo.Name = model.Name; 
           foo.Title = model.Title;
           
           if(!id.HasValue)
           {
              data.MyEFObjects.AddObject(foo);
           }
           
           data.SaveChanges();
        }
    }
