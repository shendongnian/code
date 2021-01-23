    static void Main(string[] args)
    {
      Dictionary<StudentType, List<Student>> studentDict = new Dictionary<StudentType, List<Student>>();
      var dicTwo = studentDict.ToDictionary(item => item.Key, item => (IList<Student>)item.Value);
      foo(dicTwo);
    }
