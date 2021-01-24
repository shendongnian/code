         public class MyMapper : EntityMap<MyClassName>
         {
             public MyMapper()
             {
                 Map(i => i.MyPropery).ToColumn("MyCustomPropery");
             }   
    
         }
