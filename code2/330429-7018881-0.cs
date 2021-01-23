    public class StackOverflow_7010654
    {
        [MessageContract(IsWrapped = false)]
        public class MyMC
        {
            [MessageBodyMember]
            public string MyMessage { get; set; }
        }
        public static void Test()
        {
            TypedMessageConverter tmc = TypedMessageConverter.Create(typeof(MyMC), "Action");
            Message msg = tmc.ToMessage(new MyMC { MyMessage = "some string" }, MessageVersion.Soap11);
            Console.WriteLine(msg); // message with the <MyMessage> element
            Console.WriteLine();
            msg = Message.CreateMessage(MessageVersion.Soap11, "Action", new MyBodyWriter());
            Console.WriteLine(msg); // message without the <MyMessage> element
        }
        public class MyBodyWriter : BodyWriter
        {
            public MyBodyWriter() : base(true) { }
            protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
            {
                writer.WriteString("some string");
            }
        }
    }
