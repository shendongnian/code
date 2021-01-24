        public abstract class Animal
            {
                public int id { get; private set; }
                public double amtWater { get; private set; }
                public double dailyCost { get; private set; }
                public double weight { get; private set; }
                public int age { get; private set; }
                public string color { get; private set; }
                public Animal(System.Data.IDataRecord record)
                {
                    this.id = Convert.ToInt32(record["id"].ToString());
                    this.amtWater = Convert.ToDouble(record["amtWater"].ToString());
                    this.dailyCost = Convert.ToDouble(record["dailyCost"].ToString());
                    this.weight = Convert.ToDouble(record["weight"].ToString());
                    this.age = Convert.ToInt32(record["age"].ToString());
                    this.color =  record["color"].ToString();
                }
            }
            public class Cow:Animal
            {
                public double amtMilk { get; private set; }
                public bool isJersy { get; private set; }
                public Cow(System.Data.IDataRecord record):base(record)
                {
                    this.amtMilk = Convert.ToDouble(record["amtMilk"].ToString());
                    this.isJersy = Convert.ToBoolean(record["isJersy"].ToString());
                }
            }
            public class Goat : Animal
            {
                public double amtMilk { get; private set; }
                public Goat(System.Data.IDataRecord record) : base(record)
                {
                    this.amtMilk = Convert.ToDouble(record["amtMilk"].ToString()); 
                }
            }
            public class Sheep : Animal
            {
                public double amtWool { get; private set; }
                public Sheep(System.Data.IDataRecord record) : base(record)
                {
                    this.amtWool = Convert.ToDouble(record["amtWool"].ToString());
                }
            }
