    public class MyAppleEntity : IEntity  {
      [... implement IEntity contract normally ... ]
    }
      
      .....
      public T read<T>() where T: IEntity, new() {
        DataRow dr = [reading from database]
        return new T().RowToObj(dr);
      }
        
