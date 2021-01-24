    public class Table {
      //DONE: Do not expose fields but readonly properties 
      //DONE: Keep static (i.e. global) members (fields, properties, methods) being thread safe
      private static ConcurrentDictionary<int, Table> s_Tables = 
        new ConcurrentDictionary<int, Table>();
      public Table(int ID) { 
        s_Tables.Add(ID, this);
      }
      //DONE: All we expose is thead safe read-only version of the dictionary
      public static IReadOnlyDictionary<int, Table> Tables => s_Tables;
    }
