     public class MyEnt
        {
         public string Name {get; set;}
         public string Type {get; set;}
         public LoadMyEnt(object [] array)
          {
             this.Name = array[0].ToString();
             this.Type = array[1].ToString();   
          }
        }
