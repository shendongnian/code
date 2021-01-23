    public class StackOverflow_6915554
    {
        [DataContract]
        [KnownType(typeof(LeafExpression))]
        [KnownType(typeof(BinaryExpression))]
        public class Expression
        {
        }
        [DataContract]
        public class LeafExpression : Expression
        {
            [DataMember]
            public string Name;
        }
        [DataContract]
        public class BinaryExpression : Expression
        {
            [DataMember]
            public BinaryOperator Operator;
            [DataMember]
            public Expression Left;
            [DataMember]
            public Expression Right;
        }
        public enum BinaryOperator
        {
            And,
            Or,
        }
        public static void Test()
        {
            List<Expression> expressions = new List<Expression>();
            expressions.Add(new BinaryExpression
            {
                Left = new BinaryExpression
                {
                    Left = new LeafExpression { Name = "A" },
                    Operator = BinaryOperator.And,
                    Right = new LeafExpression { Name = "B" },
                },
                Operator = BinaryOperator.Or,
                Right = new BinaryExpression
                {
                    Left = new LeafExpression { Name = "C" },
                    Operator = BinaryOperator.And,
                    Right = new LeafExpression { Name = "D" },
                }
            });
            expressions.Add(new BinaryExpression
            {
                Left = new LeafExpression { Name = "E" },
                Operator = BinaryOperator.Or,
                Right = new LeafExpression { Name = "F" }
            });
            expressions.Add(new LeafExpression { Name = "G" });
            XmlWriterSettings ws = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "  ",
                Encoding = new UTF8Encoding(false),
                OmitXmlDeclaration = true,
            };
            MemoryStream ms = new MemoryStream();
            XmlWriter w = XmlWriter.Create(ms, ws);
            DataContractSerializer dcs = new DataContractSerializer(typeof(List<Expression>));
            dcs.WriteObject(w, expressions);
            w.Flush();
            Console.WriteLine(Encoding.UTF8.GetString(ms.ToArray()));
        }
    }
