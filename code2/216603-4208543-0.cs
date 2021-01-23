        public class Animal
        {
            public static Animal Load(DataRow row)
            {
                if (row["Type"].ToString() == "Zebra")
                {
                    return new Zebra();
                }
                else if (row["Type"].ToString() == "Elephant")
                {
                    return new Elephant();
                }
    
                return null;
            }
        }
    
        public class Zebra : Animal
        {
            //some code here
        }
    
        public class Elephant : Animal
        {
            //some code here
        }
