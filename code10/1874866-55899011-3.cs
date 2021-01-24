    public class Program {
      //DONE: Do not expose fields but readonly properties 
      private Dictionary<int,Table> s_Tables = new Dictionary<int, Table>();
      public Program() {
        Table A = new Table (10);
        s_Tables.Add(10,A); 
        ...
      }
      //DONE: All we expose is read-only version of the dictionary
      public IReadOnlyDictionary<int, Table> Tables = s_Tables; 
    }
    ...
    //DONE: please, do not cram all the logic into `Main`, 
    //      have a special classes business logic (Program) and entry point
    public static class EntryPoint {
      static void Main(string[] args) {
        Program program = new Program();
        ...
      }
    }
