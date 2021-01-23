    using System;
    using System.Collections.Generic;
    using System.Web.Script.Serialization;
    
    namespace JsonSer {
        public class MyTag {
            public string tagName { get; set; }
            public string tagType { get; set; }
            public long tagCreateDate { get; set; }
            public int tagOffset { get; set; }
        }
        public enum MyMedia {
            Diskette,
            UsbStick,
            Disk,
            Internet
        }
        public class MyConversation {
            public string conversationId { get; set; }
            public string state { get; set; }
            public string conversationType { get; set; }
            public MyMedia mediaType { get; set; }
            public long startDate { get; set; }
            public int duration { get; set; }
            public List<MyTag> tags { get; set; }
        }
        public class MyConversations {
            public List<MyConversation> conversations { get; set; }
        }
        public class MyData {
            public string responseCode { get; set; }
            public string responseMessage { get; set; }
            public MyConversations responseBody { get; set; }
        }
        class Program {
            static void Main (string[] args) {
                MyData data = new MyData () {
                    responseCode = "200",
                    responseMessage = "OK",
                    responseBody = new MyConversations () {
                        conversations = new List<MyConversation> () {
                             new MyConversation() {
                                 conversationId = "conversation1",
                                 state = "state1",
                                 conversationType = "per JSON",
                                 mediaType = MyMedia.Internet,
                                 startDate = DateTime.Now.Ticks,
                                 duration = 12345,
                                 tags = new List<MyTag>() {
                                     new MyTag() {
                                         tagName = "tagName1",
                                         tagType = "tagType1",
                                         tagCreateDate = DateTime.Now.Ticks,
                                         tagOffset = 1
                                     }
                                 }
                             }
                         }
                    }
                };
    
                Console.WriteLine ("The original data has responseCode={0}", data.responseMessage);
                JavaScriptSerializer serializer = new JavaScriptSerializer ();
                string json = serializer.Serialize (data);
                Console.WriteLine ("Data serialized with respect of JavaScriptSerializer:");
                Console.WriteLine (json);
                MyData d = (MyData)serializer.Deserialize<MyData> (json);
                Console.WriteLine ("After deserialization responseCode={0}", d.responseMessage);
            }
        }
    }
