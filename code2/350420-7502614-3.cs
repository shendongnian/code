    using System;
    using System.Collections.Generic;
    using System.Text;
    
    
    namespace SessionModuleUnitTest
    {
    
    
        public class Program
        {
    
    
            [Serializable()]
            [System.Xml.Serialization.XmlRoot(ElementName = "SessionData")]
            public class cSessionData
            {
    
                [System.Xml.Serialization.XmlElement(ElementName = "key")]
                public string key;
    
                [System.Xml.Serialization.XmlElement(ElementName = "assembly")]
                public string AssemblyQualifiedName;
    
                [System.Xml.Serialization.XmlElement(ElementName = "value")]
                public string m_value;
    
                [System.Xml.Serialization.XmlIgnore()]
                public object value
                {
    
                    get 
                    {
                        object obj = null;
    
                        if (m_value == null)
                            return obj;
    
                        // Type.GetType only looks in the currently executing assembly and mscorlib 
                        // unless you specify the assembly name as well.
                        //Type T = Type.GetType(this.datatype);
                        Type T = Type.GetType(this.AssemblyQualifiedName);
                        obj = DeSerializeSOAP(m_value);
                        
                        return obj; 
                    } // End Get
    
                    set
                    { 
                        //this.m_value = value;
                        //Console.WriteLine("Type: " + obj.GetType().FullName + ", Serializable: " + obj.GetType().IsSerializable);
    
                        if (value != null)
                        {
                            //this.datatype = value.GetType().FullName;
                            this.AssemblyQualifiedName = value.GetType().AssemblyQualifiedName;
    
                            if (value.GetType().IsSerializable)
                            {
                                this.m_value = SerializeSOAP(value);
                            }
                            else
                                this.value = null;
                        }
                        else
                        {
                            this.AssemblyQualifiedName = null;
                            this.value = null;
                        }
                    } // End Set
                } // End Property value
    
    
                public cSessionData()
                { 
                } // End Constructor
    
    
                public cSessionData(string strKey, object obj)
                {
                    this.key = strKey;
                    this.value = obj;
                } // End Constructor
                
    
            } // End Class cSessionData
    
    
            //public static void InsertSessionData(cSessionData SessionData)
            public static void InsertSessionData(string strSessionUID, string strSessionID, string strKey, string strValue, string strDataType)
            {
                strSessionUID = strSessionUID.Replace("'", "''");
                strSessionID = strSessionID.Replace("'", "''");
                strKey = strKey.Replace("'", "''");
                strValue = strValue.Replace("'", "''");
                strDataType = strDataType.Replace("'", "''");
    
                string strSQL = @"
                INSERT INTO dbo.T_SessionValues
                (
                     Session_UID
                    ,Session_ID
                    ,Session_Key
                    ,Session_Value
                    ,Session_DataType
                )
                VALUES
                (
                     '" + strSessionUID + @"'  --<Session_UID, uniqueidentifier, newid()>
                    ,N'" + strSessionID + @"'  --<Session_ID, nvarchar(84), NULL>
                    ,N'" + strKey + @"'        --<Session_Key, nvarchar(100), NULL>
                    ,N'" + strValue + @"'      --<Session_Value, nvarchar(max),NULL>
                    ,N'" + strDataType + @"'   --<Session_DataType, nvarchar(4000),NULL>
                )
                ";
                //System.Runtime.Serialization.Formatters.Binary.
                COR.SQL.MS_SQL.Execute(strSQL);
            }
    
    
    
            // Add reference to System.Runtime.Serialization.Formatters.Soap
            public static string SerializeSOAP(object obj)
            {
                string strSOAP = null;
                System.Runtime.Serialization.Formatters.Soap.SoapFormatter serializer = new System.Runtime.Serialization.Formatters.Soap.SoapFormatter();
    
                using (System.IO.MemoryStream memStream = new System.IO.MemoryStream())
                {
                    serializer.Serialize(memStream, obj);
    
                    long pos = memStream.Position;
                    memStream.Position = 0;
    
                    using (System.IO.StreamReader reader = new System.IO.StreamReader(memStream))
                    {
                        strSOAP = reader.ReadToEnd();
                        memStream.Position = pos;
                        reader.Close();
                    }
                }
                return strSOAP;
            }
    
    
            public static object DeSerializeSOAP(string SOAP)
            {
                if (string.IsNullOrEmpty(SOAP))
                {
                    throw new ArgumentException("SOAP can not be null/empty");
                }
                using (System.IO.MemoryStream Stream = new System.IO.MemoryStream(UTF8Encoding.UTF8.GetBytes(SOAP)))
                {
                    System.Runtime.Serialization.Formatters.Soap.SoapFormatter Formatter = new System.Runtime.Serialization.Formatters.Soap.SoapFormatter();
                    return Formatter.Deserialize(Stream);
                }
            }
    
    
            public static System.Collections.ArrayList GetData()
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                dt.Columns.Add("abc", typeof(string));
                dt.Columns.Add("def", typeof(int));
    
                System.Data.DataRow dr = dt.NewRow();
                dr["abc"] = "test1";
                dr["def"] = 123;
                dt.Rows.Add(dr);
    
    
                dr = dt.NewRow();
                dr["abc"] = "test2";
                dr["def"] = 456;
                dt.Rows.Add(dr);
    
                System.Data.DataSet ds = new System.Data.DataSet();
                ds.Tables.Add(dt);
    
                cSessionData ObjectToSerialize1 = new cSessionData("key1", "value1");
                cSessionData ObjectToSerialize2 = new cSessionData("key2", "value2");
                cSessionData ObjectToSerialize3 = new cSessionData("key3", dt);
                
                System.Collections.ArrayList al = new System.Collections.ArrayList();
                al.Add(ObjectToSerialize1);
                al.Add(ObjectToSerialize2);
                al.Add(ObjectToSerialize3);
                return al;
            }
    
    
            public static void Deserialize(string strSOAP)
            {
    
                System.Collections.ArrayList myal = (System.Collections.ArrayList)DeSerializeSOAP(strSOAP);
    
                foreach (cSessionData SessionData in myal)
                {
                    Console.WriteLine(SessionData.key + "=" + SessionData.value);
                }
    
                cSessionData MySessionData = (cSessionData)myal[2];
                Console.WriteLine(MySessionData.key + "=" + MySessionData.value);
                System.Data.DataTable d = (System.Data.DataTable)MySessionData.value;
                Console.WriteLine(d.Rows[0]["def"]);
            }
    
    
            public static string Serialize(System.Collections.ArrayList al)
            {
                // http://www.java2s.com/Tutorial/CSharp/0220__Data-Structure/SerializeanArrayListobjecttoabinaryfile.htm
                // http://www.java2s.com/Tutorial/CSharp/0220__Data-Structure/DeserializeanArrayListobjectfromabinaryfile.htm
                
                string strSerializedItem = SerializeSOAP(al);
                Console.WriteLine(strSerializedItem);
                return strSerializedItem;
            }
    
    
            static void Main(string[] args)
            {
                //InsertSessionData(System.Guid.NewGuid().ToString(), "fdslfkjsdalfj", "Key1", "Value1", typeof(System.Data.DataTable).AssemblyQualifiedName);
                string strSOAP = Serialize(GetData());
                Deserialize(strSOAP);
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine(" --- Press any key to continue --- ");
                Console.ReadKey(true);
            } // End Sub Main
    
    
        } // End Class Program
    
    
    } // Namespace SessionModuleUnitTest
