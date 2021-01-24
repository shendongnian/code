    using Oracle.DataAccess.Client;
    using Oracle.DataAccess.Types;
    using System;
    using System.Data;
    
    namespace Strace_CustomTypes
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Setup Ref - https://o7planning.org/en/10509/connecting-to-oracle-database-using-csharp-without-oracle-client
                // ODAC 64bit ODAC122010Xcopy_x64.zip - https://www.oracle.com/technetwork/database/windows/downloads/index-090165.html
                // .Net Framework 4
    
                // 'Connection string' to connect directly to Oracle.
                string connString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=0.0.0.0)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=SIT)));Password=PASSWORD;User ID=USERID";
    
    
                OracleConnection straceOracleDBConn = new OracleConnection(connString);
                OracleCommand cmd = new OracleCommand("PKG_TEMP.TEST_ARRAY", straceOracleDBConn);
                cmd.CommandType = CommandType.StoredProcedure;
    
                try
                {
                    straceOracleDBConn.Open();
    
                    CustomVarray pScanResult = new CustomVarray();
    
                    pScanResult.Array = new string[] { "hello", "world" };
    
                    OracleParameter param = new OracleParameter();
                    param.OracleDbType = OracleDbType.Array;
                    param.Direction = ParameterDirection.Input;
    
                    param.UdtTypeName = "USERID.VARCHAR2_ARRAY";
                    param.Value = pScanResult;
                    cmd.Parameters.Add(param);
    
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
    
                    Console.WriteLine($"Error: {ex.Message} {Environment.NewLine} {ex.StackTrace}");
                }
                finally
                {
                    straceOracleDBConn.Close();
                    cmd.Dispose();
                    straceOracleDBConn.Dispose();
                }
    
                Console.WriteLine("Press any key to exit");
                Console.ReadLine();
            }
        }
    
        //Ref https://www.codeproject.com/Articles/33829/How-to-use-Oracle-11g-ODP-NET-UDT-in-an-Oracle-Sto
        public class CustomVarray : IOracleCustomType, INullable
        {
            [OracleArrayMapping()]
            public string[] Array;
    
            private OracleUdtStatus[] m_statusArray;
            public OracleUdtStatus[] StatusArray
            {
                get
                {
                    return this.m_statusArray;
                }
                set
                {
                    this.m_statusArray = value;
                }
            }
    
            private bool m_bIsNull;
    
            public bool IsNull
            {
                get
                {
                    return m_bIsNull;
                }
            }
    
            public static CustomVarray Null
            {
                get
                {
                    CustomVarray obj = new CustomVarray();
                    obj.m_bIsNull = true;
                    return obj;
                }
            }
    
    
            public void FromCustomObject(OracleConnection con, IntPtr pUdt)
            {
                OracleUdt.SetValue(con, pUdt, 0, Array, m_statusArray);
            }
    
            public void ToCustomObject(OracleConnection con, IntPtr pUdt)
            {
                object objectStatusArray = null;
                Array = (string[])OracleUdt.GetValue(con, pUdt, 0, out objectStatusArray);
                m_statusArray = (OracleUdtStatus[])objectStatusArray;
            }
        }
    
        [OracleCustomTypeMapping("USERID.VARCHAR2_ARRAY")]
        public class CustomVarrayFactory : IOracleArrayTypeFactory, IOracleCustomTypeFactory
        {
            public Array CreateArray(int numElems)
            {
                return new string[numElems];
            }
    
            public IOracleCustomType CreateObject()
            {
                return new CustomVarray();
            }
    
            public Array CreateStatusArray(int numElems)
            {
                return new OracleUdtStatus[numElems];
            }
        }
    }
