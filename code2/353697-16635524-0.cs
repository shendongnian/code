    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    
    namespace SerializeRandom
    {
        [Serializable]  // added after the fact
        public class RandomGenerator
        {
            const string fileName = "random.bin";
            private Random random = new Random();
    
            public int GetNext()
            {
                return random.Next(100);
            }
    
            public static void Save(RandomGenerator obj)
            {
                using (var stream = File.Open(fileName, FileMode.Create))
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(stream, obj);
                }
            }
    
            public static RandomGenerator Load()
            {
                RandomGenerator randomGenerator = null;
    
                //create new object if file not exist
                if (!File.Exists(fileName))
                {
                    randomGenerator = new RandomGenerator();
                }
                else
                {
                    //load from bin file
                    using (var stream = File.Open(fileName, FileMode.Open))
                    {
                        var formatter = new BinaryFormatter();
    
                        randomGenerator = (RandomGenerator)formatter.Deserialize(stream);
                        stream.Close();
                    }
                }
    
                return randomGenerator;
            }
    
        }
    
        }
