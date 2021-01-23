    using System.Diagnostics;
    using System.IO;
    using NUnit.Framework;
    using ProtoBuf;
    using ProtoBuf.Meta;
    
    namespace Examples.Issues
    {
        [TestFixture]
        public class SO7078615
        {
            [ProtoContract] // treat the interface as a contract
            // since protobuf-net *by default* doesn't know about type metadata, need to use some clue
            [ProtoInclude(1, typeof(DogBarkedEvent))]
            // other concrete messages here; note these can also be defined at runtime - nothing *needs*
            // to use attributes
            public interface IMessage { }
            public interface IEvent : IMessage { }
    
            [ProtoContract] // removed (InferTagFromName = true) - since you are already qualifying your tags
            public class DogBarkedEvent : IEvent
            {
                [ProtoMember(1)] // .proto tags are 1-based; blame google ;p
                public string NameOfDog { get; set; }
                [ProtoMember(2)]
                public int Times { get; set; }
            }
    
            [ProtoContract]
            class DontAskWrapper
            {
                [ProtoMember(1)]
                public IMessage Message { get; set; }
            }
    
            [Test]
            public void RoundTripAnUnknownMessage()
            {
                IMessage msg = new DogBarkedEvent
                {
                      NameOfDog = "Woofy", Times = 5
                }, copy;
                var model = TypeModel.Create(); // could also use the default model, but
                using(var ms = new MemoryStream()) // separation makes life easy for my tests
                {
                    var tmp = new DontAskWrapper {Message = msg};
                    model.Serialize(ms, tmp);
                    ms.Position = 0;
                    string hex = Program.GetByteString(ms.ToArray());
                    Debug.WriteLine(hex);
                   
                    var wrapper = (DontAskWrapper)model.Deserialize(ms, null, typeof(DontAskWrapper));
                    copy = wrapper.Message;
                 }
                // check the data is all there
                Assert.IsInstanceOfType(typeof(DogBarkedEvent), copy);
                var typed = (DogBarkedEvent)copy;
                var orig = (DogBarkedEvent)msg;
                Assert.AreEqual(orig.Times, typed.Times);
                Assert.AreEqual(orig.NameOfDog, typed.NameOfDog);
            }
        }
    }
