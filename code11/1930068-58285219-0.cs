    public class Test {
      public List<string> _list;
      public Test(List<string> list) {
        // We should validate public members arguments
        if (null == list)
          throw new ArgumentNullException(nameof(list));
        _list = list;
      }
      public bool EnableTest1 => _list.All(x => x == "Test1");
      public bool EnableTest2 => !EnableTest1 && _list.All(x => x == "Test2");
      public bool EnableTest3 => _list.All(x => x == "Test3");
      public bool EnableTest4 => _list.All(x => x == "Test4");
    }
