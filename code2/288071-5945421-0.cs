    class SampleData
    {
       public string Name
       {
           get;set;
       }
       public int Id
       {
           get;set;
       }
    
       public override string ToString()
       {
           return this.Name + this.Id;
       }
    }
