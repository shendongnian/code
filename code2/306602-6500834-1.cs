    class Student
    {
        public string Name {get; set;}
        public int Age { get; set; }
    }
    public void TestExecuteMultipleCommandStrongType()
    {
        connection.Execute("create table #t(Name nvarchar(max), Age int)");
        int tally = connection.Execute(@"insert #t (Name,Age) values(@Name, @Age)", new List<Student> 
        {
            new Student{Age = 1, Name = "sam"},
            new Student{Age = 2, Name = "bob"}
        });
        int sum = connection.Query<int>("select sum(Age) from #t drop table #t").First();
        tally.IsEqualTo(2);
        sum.IsEqualTo(3);
    }
