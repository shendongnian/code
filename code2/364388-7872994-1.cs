      UserControl myControl = null;    
      Assembly asm = Assembly.LoadFile(Your dll path);
      Type[] tlist = asm.GetTypes();
      foreach (Type t in tlist)
      {
         if(t.Name == "Your class name" )
         {
             myControl = Activator.CreateInstance(t) as UserControl;
             break;
         }               
      }
