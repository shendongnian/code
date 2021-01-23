    class ComboBoxIntItem
    {
      private int _id;
      private string _name;
      public ComboBoxIntItem(int id, string name)
      {
        _id = id;
        _name = name;
      }
      public override string ToString()
      {
        return _name;
      }
    }
