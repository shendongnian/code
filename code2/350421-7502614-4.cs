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
                        
                        System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(T);
    
                        System.IO.StringReader sr = new System.IO.StringReader(m_value);
                        obj = ser.Deserialize(sr);
                        sr.Close();
                        //sr.Dispose();
                        sr = null;
                        ser = null;
    
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
                                System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(value.GetType());
                                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                                System.IO.StringWriter writer = new System.IO.StringWriter(sb);
                                ser.Serialize(writer, value);
                                this.m_value = sb.ToString();
                                writer.Close();
                                //writer.Dispose();
                                sb = null;
                                writer = null;
                                ser = null;
                            }
                            else
                                this.m_value = null;
                        }
                        else
                        {
                            this.AssemblyQualifiedName = null;
                            this.m_value = null;
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
    
    
            public static string Serialize(System.Collections.ArrayList al)
            {
                Type[] theExtraTypes = new Type[2];
                theExtraTypes[0] = typeof(System.Collections.ArrayList);
                theExtraTypes[1] = typeof(cSessionData);
    
                System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(System.Collections.ArrayList), theExtraTypes);
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                System.IO.StringWriter writer = new System.IO.StringWriter(sb);
    
                ser.Serialize(writer, al);
                string strSerializedItem = sb.ToString();
                sb = null;
                writer.Close();
                //writer.Dispose();
                writer = null;
                ser = null;
    
                /*
                System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
                xmlDoc.LoadXml(sb.ToString());
    
                
                System.IO.StringWriter sw = new System.IO.StringWriter();
    	        System.Xml.XmlTextWriter xw = new System.Xml.XmlTextWriter(sw);
    	        xmlDoc.WriteTo(xw);
    	        string strSerialized = sw.ToString();
                xw.Close();
                sw.Close();
                //sw.Dispose();
                */
                return strSerializedItem;
            }
    
    
            public static void Serialization()
            {
                // http://www.java2s.com/Tutorial/CSharp/0220__Data-Structure/SerializeanArrayListobjecttoabinaryfile.htm
                // http://www.java2s.com/Tutorial/CSharp/0220__Data-Structure/DeserializeanArrayListobjectfromabinaryfile.htm
    
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
    
                Console.WriteLine("tname: " + dt.GetType().FullName);
    
                cSessionData ObjectToSerialize1 = new cSessionData("key1", "value1");
                cSessionData ObjectToSerialize2 = new cSessionData("key2", "value2");
                cSessionData ObjectToSerialize3 = new cSessionData("key3", dt);
                
    
                System.Collections.ArrayList al = new System.Collections.ArrayList();
                al.Add(ObjectToSerialize1);
                al.Add(ObjectToSerialize2);
                al.Add(ObjectToSerialize3);
    
                string strSerializedItem = Serialize(al);
                Console.WriteLine(strSerializedItem);
                Deserialize(strSerializedItem);
            }
    
    
            static void Deserialize(string strXML)
            {
                Type[] theExtraTypes = new Type[2];
                theExtraTypes[0] = typeof(System.Collections.ArrayList);
                theExtraTypes[1] = typeof(cSessionData);
    
                
                System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(System.Collections.ArrayList), theExtraTypes);
    
                System.IO.StringReader sr = new System.IO.StringReader(strXML);
                System.Collections.ArrayList myal = (System.Collections.ArrayList ) ser.Deserialize(sr);
                foreach (cSessionData SessionData in myal)
                {
                    Console.WriteLine(SessionData.key + "=" + SessionData.value);
                }
    
                cSessionData MySessionData = (cSessionData) myal[2];
                Console.WriteLine(MySessionData.key + "=" + MySessionData.value);
                System.Data.DataTable d = (System.Data.DataTable)MySessionData.value;
                Console.WriteLine(d.Rows[0]["def"]);
            } // End Sub Deserialize
    
    
            static void Main(string[] args)
            {
                Serialization();
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine(" --- Press any key to continue --- ");
                Console.ReadKey(true);
            } // End Sub Main
    
    
        } // End Class Program
    
    
    } // Namespace SessionModuleUnitTest
