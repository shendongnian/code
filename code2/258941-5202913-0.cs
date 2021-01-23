    using System;
    using System.Collections.Generic;
    using System.IO;
    using ProtoBuf;
    
    
    namespace Serialization
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] annotates = { "1", "2" };
                Guides[] g1 = new Guides[2];
                g1[0].comments = (string[])annotates.Clone();
                g1[1].comments = (string[])annotates.Clone();
    
                Guides[] g2 = new Guides[2];
                g2[0].comments = (string[])annotates.Clone();
                g2[1].comments = (string[])annotates.Clone();//to be commented later
    
                arrayStruct arrStr1 = new arrayStruct();
                arrStr1.guides_array = g1;
    
                arrayStruct arrStr2 = new arrayStruct();
                arrStr2.guides_array = g2;
    
                using (Stream file = File.Create(@"1.bin"))
                {
                    MoveAndTime mv1 = new MoveAndTime();
                    MoveAndTime mv2 = new MoveAndTime();
                    mv1.MoveStruc = "1";
                    mv1.timeHLd = DateTime.Now;
                    mv1.arr = arrStr1;
                    Serializer.SerializeWithLengthPrefix(file, mv1, PrefixStyle.Base128, Serializer.ListItemTag);
                    mv2.MoveStruc = "2";
                    mv2.timeHLd = DateTime.Now;
                    mv2.arr = arrStr2;
                    Serializer.SerializeWithLengthPrefix(file, mv2, PrefixStyle.Base128, Serializer.ListItemTag);
                }
    
                using (Stream file = File.OpenRead(@"1.bin"))
                {
                    List<MoveAndTime> MVTobjs = Serializer.Deserialize<List<MoveAndTime>>(file);
                    foreach (MoveAndTime item in MVTobjs)
                    {
                        Console.WriteLine(item.arr.guides_array[0].comments[0]);
                    }
                }
            }
    
        }
    
        [ProtoContract]
        public struct MoveAndTime
        {
            [ProtoMember(1)]
            public string MoveStruc;
            [ProtoMember(2)]
            public DateTime timeHLd;
            [ProtoMember(3)]
            public arrayStruct arr;
        }
    
        [ProtoContract]
        public struct arrayStruct
        {
            [ProtoMember(1)]
            public Guides[] guides_array;
        }
    
        [ProtoContract]
        public struct Guides
        {
            [ProtoMember(1)]
            public string[] comments;
            [ProtoMember(2)]
            public string name;
        }
    }
