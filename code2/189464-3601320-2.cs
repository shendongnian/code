    class NameCountType
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }
    ...
    return from ... in ...
           ...
           select new NameCountType
                  {
                      Name = ...,
                      Count = ...,
                  };
