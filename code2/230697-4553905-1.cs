    class ComboBoxIntItem
    {
      private readonly int _id;
      private readonly string _name;
      public ComboBoxIntItem(int id, string name)
      {
        _id = id;
        _name = name;
      }
      public override string ToString()
      {
        return _name;
      }
      public int GetId()
      {
        return _id;
      }
    }
