    public static class OneClassExtensions
    {
      public void AddMany(this OneClass self, params object[] items)
      {
        foreach(object item in items)
        {
          self.Items.Add(item);
        }
      }
    }
