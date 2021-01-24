    public void Main()
      {
          ConnectionManager conn = Dts.Connections["file.dat"];
          var path = conn.ConnectionString;
          //your encoding code 
          // if you want to access package variables use Dts.Variables["User::NeededVar"].Value;
          Dts.TaskResult = ScriptResults.Success;
      }
