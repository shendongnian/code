    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var stringvalue = getActions(false, true, false); //this result you store to your db
                Console.WriteLine(stringvalue);
                Console.ReadLine();
                var deserialised = DeserialiseActions(stringvalue); //you would have retrieved this from the database
            }
    
            public static string getActions(bool isView, bool isAddupdate, bool isDelete)
            {
                return $"{Convert.ToSByte(isView).ToString()}{Convert.ToSByte(isAddupdate).ToString()}{Convert.ToSByte(isDelete).ToString()}";
            }
    
            public static ActionsCollection DeserialiseActions(string dataValue)
            {
                return new ActionsCollection
                {
                    IsView = bool.Parse(dataValue[0].ToString()),
                    IsUpdate = bool.Parse(dataValue[1].ToString()),
                    IsDelete = bool.Parse(dataValue[2].ToString())
                };
            }
        }
    
        class ActionsCollection
        {
            public bool IsView { get; set; }
            public bool IsUpdate { get; set; }
            public bool IsDelete { get; set; }
        }
    }
