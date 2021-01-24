    using System.Linq;
    using System.Text.RegularExpressions;
    ...
    public void query(string commandText, params string[] parameters) {
      using (SqlCommand command = new SqlCommand()) {
        command.Connection = myConnection; //TODO: put the right connection here
        command.CommandText = commandText;
        var prms = Regex
          .Matches(commandText, @"\b@[A-Za-z_][A-Za-z_0-9]*\b") 
          .Cast<Match>()
          .Zip(parameters)
          .Select((match, value) => new {
             name = match.Value,
             value
           });
        foreach(var prm in prms) 
          cmd.Parameters.AddWithValue(prm.name, prm.value);
        command.ExecuteNonQuery(); 
      }
    }
