    class MyObject {
      public string name = "";
      public List<MyObject> depandantObj = new List<MyObject>();
      public MyObject(string value, params MyObject[] dependent) {
        name = value;
        if (dependent != null)
          foreach (var item in dependent)
            depandantObj.Add(item);
      }
    }
