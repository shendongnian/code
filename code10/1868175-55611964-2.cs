    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    namespace ConsoleApplication108
    {
        class Program
        {
            static void Main(string[] args)
            {
     
            }
        }
        public class MyDataReader : IDataReader 
        {
            private SqlConnection conn { get; set; }
            private SqlCommand cmd { get; set; }
            private SqlDataReader reader { get; set; }
            private string data { get; set; }
            private object[] arrayData { get; set; }
            private IEnumerator<object> m_dataEnumerator { get; set; }
            public MyDataReader(string commandText, string connectionString)
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                cmd = new SqlCommand(commandText, conn);
                reader = cmd.ExecuteReader();
                
            }
            public Boolean NextResult()
            {
                return reader.Read();
            }
            public int RecordsAffected
            {
                get { return -1; }
            }
            public int Depth
            {
                get { return -1; }
            }
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            private void Dispose(bool disposing)
            {
                if (disposing)
                {
                    if (m_dataEnumerator != null)
                    {
                        m_dataEnumerator.Dispose();
                        m_dataEnumerator = null;
                    }
                }
            }
            public Boolean IsClosed {
                get { return reader.IsClosed; }
            }
            public Boolean Read()
            {
                if (IsClosed)
                {
                    throw new ObjectDisposedException(GetType().Name);
                }
                else
                {
                    arrayData = reader.GetString(0).Split(new char[] { ',' }).ToArray();
                }
                return m_dataEnumerator.MoveNext();
            
            }
            public DataTable GetSchemaTable()
            {
                return null;
            }
            public void Close()
            {
                Dispose();
            }
               
            
            public object this[string name]
            {
                get { throw new NotImplementedException(); }
                
            }
      
            public object this[int i]
            {
                get { return arrayData[i]; }
            }
            public int FieldCount
            {
                get { return arrayData.Length; }
            }
            public bool IsDBNull(int i)
            {
                  throw new NotImplementedException();
            }
            public bool GetBoolean(int i)
            {
                throw new NotImplementedException();
            }
            public byte GetByte(int i)
            {
                throw new NotImplementedException();
            }
            public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
            {
                throw new NotImplementedException();
            }
            public char GetChar(int i)
            {
                throw new NotImplementedException();
            }
            public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
            {
                throw new NotImplementedException();
            }
            public IDataReader GetData(int i)
            {
                throw new NotImplementedException();
            }
            public string GetDataTypeName(int i)
            {
                throw new NotImplementedException();
            }
            public DateTime GetDateTime(int i)
            {
                throw new NotImplementedException();
            }
            public decimal GetDecimal(int i)
            {
                throw new NotImplementedException();
            }
            public double GetDouble(int i)
            {
                throw new NotImplementedException();
            }
            public Type GetFieldType(int i)
            {
                throw new NotImplementedException();
            }
            public float GetFloat(int i)
            {
                throw new NotImplementedException();
            }
            public Guid GetGuid(int i)
            {
                throw new NotImplementedException();
            }
            public short GetInt16(int i)
            {
                throw new NotImplementedException();
            }
            public int GetInt32(int i)
            {
                throw new NotImplementedException();
            }
            public long GetInt64(int i)
            {
                throw new NotImplementedException();
            }
            public string GetName(int i)
            {
                throw new NotImplementedException();
            }
            public string GetString(int i)
            {
                throw new NotImplementedException();
            }
            public int GetValues(object[] values)
            {
                values = arrayData;
                
                return arrayData.Length;
            }
            public int GetOrdinal(string name)
            {
                throw new NotImplementedException();
            }
            public object GetValue(int i)
            {
                return arrayData[i];
            }
        }
    }
 
