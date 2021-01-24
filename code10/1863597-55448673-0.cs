    public class People
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public double Value { get; set; }
    }
    List<People> peopleList = new List<People>()
            {
                new People { Name="grocery ",Date="01/03/2019",Value=1000 },
                new People { Name="clothes ",Date="02/03/2019",Value=250 },
                new People { Name="grocery ",Date="04/03/2019",Value=500 },
                new People { Name="clothes ",Date="01/02/2019",Value=550 },
                new People { Name="movie ",Date="03/03/2019",Value=550 },
               
            };
    var groupList = peopleList.GroupBy(x => x.Name).Select(x => new { name = x.Key,Total=x.Sum(y=>y.Value),Num=x.Distinct().Count() }).Distinct().ToList();
    Console.WriteLine("Total group Items is "+groupList.Count() );
    foreach(var item in groupList)
    {
      Console.WriteLine(item.name + " Number of times "+ item.Num + " and Value is " + item.Total);
    }
