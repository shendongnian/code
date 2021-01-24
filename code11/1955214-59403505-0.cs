        public class Student
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Rand { get; set; }
        }
        public class StudentData
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Rand { get; set; }
        }
        public static string Get()
        {
            List<Student> studentList = new List<Student>();
            Random rand = new Random();
            for (int i = 0; i < 100; i++)
            {
                int r = rand.Next(1, 1000);
                studentList.Add(new Student
                {
                    ID = i,
                    Name = "Dhruv" + i,
                    Rand = r
                });
            }
            string _JsonData = JsonConvert.SerializeObject(studentList);
            return _JsonData;
        }
In my main file, i ran the following code which does exactly what you do. Instead of calling an API that you have to get the json, i call the method Get() to get the json. Get gives you a serialized version of the data... then deserialized to another class.
    string jsonData = Get();
    //string jsonData = "[{\"ID\":0,\"Name\":\"Dhruv0\",\"Rand\":52},{\"ID\":1,\"Name\":\"Dhruv1\",\"Rand\":44},{\"ID\":2,\"Name\":\"Dhruv2\",\"Rand\":118},{\"ID\":3,\"Name\":\"Dhruv3\",\"Rand\":668},{\"ID\":4,\"Name\":\"Dhruv4\",\"Rand\":142},{\"ID\":5,\"Name\":\"Dhruv5\",\"Rand\":864},{\"ID\":6,\"Name\":\"Dhruv6\",\"Rand\":150},{\"ID\":7,\"Name\":\"Dhruv7\",\"Rand\":412},{\"ID\":8,\"Name\":\"Dhruv8\",\"Rand\":515},{\"ID\":9,\"Name\":\"Dhruv9\",\"Rand\":105}]";
    Console.WriteLine(jsonData);
    List<StudentData> item = JsonConvert.DeserializeObject<List<StudentData>>(jsonData);
    foreach(var i in item)
    {
        Console.WriteLine("ID: " + i.ID);
        Console.WriteLine("Name: " + i.Name.ToUpper());
        Console.WriteLine("Rand No: " + i.Rand);
    }
Both jsonData from Get() method and that string works correctly and gives you the desired output.
ID: 0
Name: DHRUV0
Rand No: 52
ID: 1
Name: DHRUV1
Rand No: 44
... // hiding 2 - 7 
ID: 8
Name: DHRUV8
Rand No: 515
ID: 9
Name: DHRUV9
Rand No: 105
There is nothing wrong with the code.. Only thing that does not work is your https://localhost call that is supossed to retrieve the json string. Once you fix your API, you'll get the methods working.
