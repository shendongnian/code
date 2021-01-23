      public class Animal
        {
            public Animal()
            {
                name = "Test";
            }
            public string name { get; set; }
        }
    
        [Serializable]
        public class Cat : Animal
        {
            public string color {get; set;}
        }
            var acat = new Cat();
            acat.color = "Green";
            Stream stream = File.Open("test.bin", FileMode.Create);
            BinaryFormatter bformatter = new BinaryFormatter();
            bformatter.Serialize(stream, acat);
            stream.Close();
