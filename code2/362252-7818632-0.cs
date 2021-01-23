    using System;
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using System.Configuration;
    
    class EntryPoint
    {
        [DllImport("libmySQL.dll")]
        static extern IntPtr mysql_init(IntPtr mysql);
    
        [DllImport("libmySQL.dll")]
        static extern IntPtr mysql_fetch_lengths(IntPtr result);
    
        [DllImport("libmySQL.dll")]
        static extern IntPtr mysql_store_result(IntPtr mysql);
    
        [DllImport("libmySQL.dll")]
        static extern IntPtr mysql_fetch_row(IntPtr result);
    
        [DllImport("libmySQL.dll")]
        static extern IntPtr mysql_real_connect(IntPtr mysql, string host, string user, string passwd, string db, uint port, string unix_socket, uint client_flag);
    
        [DllImport("libmySQL.dll")]
        static extern uint mysql_field_count(IntPtr mysql);
    
        [DllImport("libmySQL.dll")]
        static extern string mysql_error(IntPtr mysql);
    
        [DllImport("libmySQL.dll")]
        static extern int mysql_real_query(IntPtr mysql, string query, uint length);
    
        static Array MarshalArray(Type structureType, IntPtr arrayPtr, int length)
        {
            if (structureType == null)
                throw new ArgumentNullException("structureType");
            if (!structureType.IsValueType)
                throw new ArgumentException("Only struct types are supported.", "structureType");
            if (length < 0)
                throw new ArgumentOutOfRangeException("length", length, "length must be equal to or greater than zero.");
            if (arrayPtr == IntPtr.Zero)
                return null;
            int size = System.Runtime.InteropServices.Marshal.SizeOf(structureType);
            Array array = Array.CreateInstance(structureType, length);
            for (int i = 0; i < length; i++)
            {
                IntPtr offset = new IntPtr((long)arrayPtr + (size * i));
                object value = System.Runtime.InteropServices.Marshal.PtrToStructure(offset, structureType);
                array.SetValue(value, i);
            }
            return array;
        }
    
    
        static void mysql_real_query(IntPtr mysql, string query)
        {
            int result = (query != null) ? mysql_real_query(mysql, query, (uint)query.Length) : mysql_real_query(mysql, null, 0);
            if (result == 0)
                return;
            throw new ApplicationException(mysql_error(mysql));
        }
    
        static int Main(string[] args)
        {
            IntPtr ptr = mysql_init(IntPtr.Zero);
            Debug.Assert(ptr != IntPtr.Zero);
    
            IntPtr mysql = mysql_real_connect(ptr, ConfigurationSettings.AppSettings["server"], ConfigurationSettings.AppSettings["username"], ConfigurationSettings.AppSettings["password"], ConfigurationSettings.AppSettings["database"], 0, null, 0);
            Debug.Assert(ptr != IntPtr.Zero, mysql_error(ptr));
    
            string query = "SELECT * FROM proxy_servers";
            Console.WriteLine("Executing query: {0}", query);
            mysql_real_query(mysql, query);
    
            IntPtr result = mysql_store_result(mysql);
            Debug.Assert(result != IntPtr.Zero, mysql_error(mysql));
    
            uint fieldCount = mysql_field_count(mysql);
            Console.WriteLine("field count: {0}", fieldCount);
    
            for (IntPtr ptrRow = mysql_fetch_row(result); ptrRow != IntPtr.Zero; ptrRow = mysql_fetch_row(result))
            {
                IntPtr[] mysqlRow = (IntPtr[])MarshalArray(typeof(IntPtr), ptrRow, (int)fieldCount);
                IntPtr ptrLengths = mysql_fetch_lengths(result);
                uint[] lengths = (uint[])MarshalArray(typeof(uint), ptrLengths, (int)fieldCount);
                for (int i = 0; i < (int)fieldCount; i++)
                {
                    string str = Marshal.PtrToStringAnsi(mysqlRow[i], (int)lengths[i]);
                    Console.Write("{0}, ", str);
                }
                Console.WriteLine();
            }
            return 0;
        }
    }
