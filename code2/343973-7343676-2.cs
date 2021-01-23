    using System;
    using System.Collections.Generic;
    using System.IO;
    using ProtoBuf;
    [ProtoContract]
    public class Word {
        [ProtoMember(1)]
        public string Foo { get; set; }    
        [ProtoMember(2)]
        public string Bar { get; set; }
    }
    static class Program {
        public static void Main() {
            var data = new Dictionary<string, List<Word>>{
                {"abc", new List<Word> {
                    new Word { Foo = "def", Bar = "ghi"},
                    new Word { Foo = "jkl", Bar = "mno"}
                }},
                {"pqr", new List<Word> {
                    new Word {Foo = "stu", Bar = "vwx"}
                }}
            };
            using(var file = File.Create("my.bin")) {
                Serializer.Serialize(file, data);
            }
            Dictionary<string, List<Word>> clone;
            using(var file = File.OpenRead("my.bin")) {
                clone = Serializer.Deserialize<
                     Dictionary<string, List<Word>>>(file);
            }
            foreach(var pair in clone) {
                Console.WriteLine(pair.Key);
                foreach(var word in pair.Value){
                    Console.WriteLine("\t{0} | {1}", word.Foo, word.Bar);
                }
            }    
        }
    }
