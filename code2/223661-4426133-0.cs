    public partial class StoredProcedures
    {
        [Microsoft.SqlServer.Server.SqlProcedure]
        public static void StoredProcedure1(object param1)
        {
            // Put your code here
            //Trace.Write(param1);
            SqlContext.Pipe.Send(param1.ToString());
    
        }
    };
