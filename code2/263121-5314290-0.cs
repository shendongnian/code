        public class myClass
        {
            public enum myEnum
            {
                Item1,
                Item2
            }
        }
        public class otherClass
        {
            public otherClass()
            {
                if (Enum.GetNames(typeof(myClass.myEnum)).Contains("Item1"))
                    Console.WriteLine("We have a match!");
            }
        }
