        [DataContractAttribute()]
        public class Message
        {  
            public Message()  
            {
                ID = Guid.NewGuid();
                TimeCreated = DateTime.Now;
            }
            [DataMemberAttribute()]
            Guid ID { get; private set; }
            [DataMemberAttribute()]
            DateTime TimeCreated { get; private set; }
            [DataMemberAttribute()]
            String Content {get; set;}
        } 
