    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Oracle.DataAccess.Client;
    using System.Data;
    namespace ConsoleApplication3
    {
    class Program
    {
        public static void Main(string[] args)
        {
            OracleConnection cn = new OracleConnection("your connection string here");
            string sql = "INSERT INTO testtable(testname) VALUES('testing2') RETURNING id INTO :LASTID";
            OracleParameter lastId = new OracleParameter(":LASTID", OracleDbType.Int32);
 
            lastId.Direction = ParameterDirection.Output;
            using (OracleCommand cmd = new OracleCommand(sql, cn))
            {
                cn.Open();
                cmd.Parameters.Add(lastId);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Last ID: " + lastId.Value.ToString());
                cn.Close();
            }
            Console.WriteLine();
            Console.ReadKey(false);
        }
    }
    }
