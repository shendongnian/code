    struct Key
    {
        string Name;
        int Id;
        int SchoolId;
    }
    class DictionaryObject
    {
       IDictionary<Key, double> _dict;
    
       public DictionaryObject(IEnumerable<Dto> dtoList)
       {
          _dict = dtoList.ToDictionary(
                 o => new Key { Name = o.Name, Id = o.Id, SchoolId = o.SchoolId },
                 o => o.Value);
       }
       double GetValue(string Name, int Id, int SchoolId)
       {
          // if the key exists then...
          return _dict[new Key { Name = Name, Id = Id, SchoolId = SchoolId }];
       }
       
       ...
    }
