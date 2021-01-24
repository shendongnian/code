    using System.Data;
    using Mono.Data.Sqlite; // Requires reference to:  C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\MonoAndroid\v1.0\Mono.Data.Sqlite.dll
    
    //...
    var cmd = new SqliteCommand(Conn) {
        CommandText = "INSERT INTO MyTable (Setting, Value) VALUES (@SETTING, @VALUE)",
        CommandType = CommandType.Text
    };
    cmd.Parameters.Add(new SqliteParameter("@SETTING", "My Setting"));    
    cmd.Parameters.Add(new SqliteParameter("@VALUE", "My Value"));
    var nRowsProcessed = cmd.ExecuteNonQuery();
    Log.Info("MyApp", $"Rows Processed: {nRowsProcessed}");
