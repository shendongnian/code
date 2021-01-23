    namespace Layer.Logic
    {
    	public class EntityObjectCommands : LogicContextBase, IEntityObjectCommands
    	{
    		public Tresult Get<Tcommand, Tresult>(Tcommand command) where Tcommand : ICommandGet
    		{
    			Tresult result = default(Tresult);
    			DBEntityObjectCommands dbfactory = new DBEntityObjectCommands(GetDataServiceParam(dbserver));
    			result = dbfactory.Get<Tcommand, Tresult>(command);		
    			return result;
    		}
    	}
    }
    namespace Layer.Data
    {
    	public class DBEntityObjectCommands : IEntityObjectCommands
    	{
    		public Tresult Get<Tcommand, Tresult>(Tcommand command) where Tcommand : ICommandGet
    		{
    		  Tresult result = default(Tresult);
    		  OleDbCommandInfo commandInfo = DBCommandProvider<Tcommand>.Get(command);
    		  
    		  //-- implement logic to use [commandInfo] ...........
    		  
    		  return result;
    		}		
    	}	
        public static class DBCommandProvider<Tcommand> where Tcommand : ICommand
        {
            public static OleDbCommandInfo Get(Tcommand command)
            {   
                return DBCommands.Get( (dynamic)command );
            }
        }	
    }
