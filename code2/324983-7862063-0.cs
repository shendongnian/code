    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace Factory
    {
        public abstract class DbServer
        {
            //method need to be implemented by inherited classes
            public abstract string GetDbServerName();
        }
        public class MsSqlServerDb : DbServer
        {
            //overridden method
            public override string GetDbServerName()
            {
                return "MS Sql Server";
            }
        }
        public class OracleDb : DbServer
        {
            //overridden method
            public override string GetDbServerName()
            {
                return "Oracle Database Server";
            }
        }
        //factory class that will be used to create objects
        public static class DatabaseFactory
        {
            //return the required object
            public static DbServer GetDb(string DbName)
            {
                if (DbName == "Ms Sql Server")
                {
                    return new MsSqlServerDb();
                }
                if (DbName == "Oracle Database Server")
                {
                    return new OracleDb();
                }
                return new MsSqlServerDb();
    
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                //get the ms sql server object
                DbServer dbServer = DatabaseFactory.GetDb("Ms Sql Server");
                //return ms sql server
                string dbName = dbServer.GetDbServerName();
                //print the name on output window
                Console.WriteLine("Server Name : " + dbName);
                //get the oracle database server object
                dbServer = DatabaseFactory.GetDb("Oracle Database Server");
                //return oracle server name
                dbName = dbServer.GetDbServerName();
                //print the name to output window
                Console.WriteLine("Server Name : " + dbName);
                Console.Read();
            }
        }
    }
