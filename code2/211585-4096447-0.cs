      {
      IEnumerable<object> objects = (new object[]{0,1,null,3}).Where(IsNull);
    
         foreach (object item in objects)
         {
            Console.WriteLine("item is null");
         }
      }
    
      bool IsNull(object arg) { return arg == null; }
