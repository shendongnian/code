    using MessagePack;
    using System;
    
    namespace ConsoleApp1
    {
        [MessagePackObject]
        public class SampleCallback : IMessagePackSerializationCallbackReceiver
        {
            [Key(0)]
            public int Key { get; set; }
    
            public void OnBeforeSerialize()
            {
                Console.WriteLine("OnBefore");
            }
    
            public void OnAfterDeserialize()
            {
                Console.WriteLine("OnAfter");
            }
        }
        class CallbackReciever
        {
    
            
    
            public static void Main()
            {
                SampleCallback b1 = new SampleCallback { Key = 1 };
    
                Console.WriteLine("Starting serialization");
                byte[] data = MessagePackSerializer.Serialize<dynamic>(b1);
    
                foreach (byte b in data)
                {
                    Console.WriteLine(b);
                }
    
                SampleCallback temp = MessagePackSerializer.Deserialize<SampleCallback>(data);
                Console.WriteLine(MessagePackSerializer.ToJson(temp));
                Console.ReadKey();
            }
            }
    }
