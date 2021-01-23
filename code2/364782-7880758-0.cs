    public class Participant
    {
       public int Id { get; private set; }
       public string Name {get; set;}
       public string Address {get; set; }
       public Participant( int id, string name, string address )
       {
           this.Id = id;
           this.Name = name;
           this.Address = address;
       }
    }
    
    public Participant GetParticipant( string name )
    {
        using( var conn = new OleDbConnection (connectionString) )
        {
            using( var cmd = connection.CreateCommand() )
            {
                  command.CommandText = "SELECT [Id], [Name], [Address] FROM Participant WHERE [name] LIKE @p_name";
    
    
                   command.Parameters.Add ("@p_name", OleDbType.VarChar).Value = name;
    
                   using( var reader = command.ExecuteReader() )
                   {
                        if( !reader.HasRows() ) return null;
    
                        reader.Read();
    
                        return new Participant (reader.GetString("Id"), reader.GetString("name"), reader.GetString("address"));
                   }
            }
        }
    
    }
