    public class StackOverflow_6780831
    {
        [DataContract(Name = "Order")]
        public class Order
        {
            [DataMember(Order = 1)]
            public int Id;
            [DataMember(Order = 2)]
            public List<object> List;
        }
        public static void Test()
        {
            MemoryStream ms = new MemoryStream();
            Order order = new Order
            {
                Id = 1,
                List = new List<object>
                {
                    1, "some string", DateTime.Now
                },
            };
            DataContractSerializer dcs = new DataContractSerializer(typeof(Order));
            XmlWriter w = XmlWriter.Create(ms, new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "  ",
                OmitXmlDeclaration = true
            });
            dcs.WriteObject(w, order);
            w.Flush();
            Console.WriteLine(Encoding.UTF8.GetString(ms.ToArray()));
        }
    }
