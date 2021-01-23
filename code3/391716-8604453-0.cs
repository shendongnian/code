    namespace Testbed {
      class Program {
        static void Main(string[] args) {
          try {
            string connStr="User Id=my_user;Password=my_pass;Data Source=my_sid;";
            OracleConnection oraConnect = new OracleConnection(connStr);
            oraConnect.Open();
            Console.WriteLine("Opened Connection");
            oraConnect.Close();
            Console.WriteLine("Complete");
            Console.ReadLine();
          catch (System.Exception e) {
            Console.WriteLine(e.Message);
            Console.ReadLine();
          } ...
