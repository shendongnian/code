    class CellInfo<T>
    {
        public string Title { get; set; }
        public string FormatString { get; set; }
        public Func<T, object> Selector { get; set; }
    }
    Dictionary<string, CellInfo<Person>> dict = new Dictionary<string, CellInfo<Person>>();
    dict.Add("LastName", new CellInfo<Person> { Selector = p => p.LastName });
    dict.Add("Age", new CellInfo<Person> { Selector = p => p.Age });
    foreach (Person p in someCollection)
    {
        foreach (var cellInfo in dict)
        {
            object value = cellInfo.Value.Selector(p);
        }
    }
