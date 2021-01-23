    public interface IEntity {
       // some constrains...
      DataRow ObjToRow(object obj);
      object RowToObj(DataRow dr);
    }
    //T would be any class inherites from IEntity with default contructor signature.
    public interface IMyContract {
      T read<T>() where T : IEntity;  
      void write<T>(T object) where T : IEntity;
    }
    
    //everything in the class is static
    public static class SqlProvider : IMyContract {
      public static T read<T>() where T: IEntity {
        DataRow dr = [reading from database]
        return T.RowToObj(dr);
      }
 
      //compile error here....
      public static void write<T>(T obj) where T : IEntity {
        DataRow dr = T.ObjToRow(obj);
        
       [ ... commit data row dr to database ... ]
      }
    }
    public static class MyAppleEntity : IEntity  {
      [... implement IEntity contract normally ... ]
    }
    public static class MyOrangeEntity : IEntity {
       [... implement IEntity contract normally ... ]
    }
    public class MyTest {
      void reading() {
         MyAppleEntity apple = SqlProvider.Read<MyAppleEntity>();
         MyOrangeEntity orange = SqlProvider.Read<MyOrangeEntity>();
       
         SqlProvider.write<MyAppleEntity>(apple); 
         SqlProvider.write<MyOrangeEntity>(orange);
      } 
         
    }
    
