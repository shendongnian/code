    partial class Car
    {
      public string Doors
      {
         get
         {
            var sb = new StringBuilder();
            foreach(var door in this.Doors)
            {
               sb.Append(door.Name);
            }
         }
         return sb.ToString();
      }
    
      public string Hinges
      {
         get
         {
            var sb = new StringBuilder();
            foreach(var door in this.Doors)
            {
               foreach(var hinge in door.Hinges)
               {
                 sb.Append(door.Name);
               }
            }
            return sb.ToString();
         }
       }
    }
