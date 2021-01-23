    using System;
    using System.Windows.Forms;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Security.Permissions;
    
    namespace DynamicTest
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {            
                dynamic dynamicContext = new DynamicContext();
                dynamicContext.Greeting = "Hello";
                this.Text = dynamicContext.Greeting;
    
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, dynamicContext);
                stream.Close();
            }
        }
    
        [Serializable]
        public class DynamicContext : DynamicObject, ISerializable
        {
            private Dictionary<string, object> dynamicContext = new Dictionary<string, object>();
    
            public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                return (dynamicContext.TryGetValue(binder.Name, out result));
            }
    
            public override bool TrySetMember(SetMemberBinder binder, object value)
            {
                dynamicContext.Add(binder.Name, value);
                return true;
            }
    
            [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
            public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                foreach (KeyValuePair<string, object> kvp in dynamicContext)
                {
                    info.AddValue(kvp.Key, kvp.Value);
                }
            }
    
            public DynamicContext()
            {
            }
    
            protected DynamicContext(SerializationInfo info, StreamingContext context)
            {
                // TODO: validate inputs before deserializing. See http://msdn.microsoft.com/en-us/library/ty01x675(VS.80).aspx
                foreach (SerializationEntry entry in info)
                {
                    dynamicContext.Add(entry.Name, entry.Value);
                }
            }
    
        }
    }
