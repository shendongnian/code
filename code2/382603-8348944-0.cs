    //Domain model to decouple from EF
    public class MyObjectModel
    { 
        public int ID {get; set;} 
        public string Name {get; set;} 
        public string Title {get; set;} 
    } 
    //Auto generated Entity Framework class
    public class MyEFObject
    { 
        public int ID {get; set;} 
        public string Name {get; set;} 
        public string Title {get; set;} 
    } 
    //Adapter responsible for mapping your data to your domain model
    public class MyObjectModelAdapter : MyEFObject
    {
        public MyObjectModelAdapter(MyEFObject entity)
        {
            if(entity != null)
            {
                this.ID = entity.ID;
                this.Name = entity.Name;
                this.Title = entity.Title;
            }
        }
    }
