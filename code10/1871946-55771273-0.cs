    public void RemoveItem(string name)
    {
      foreach (var item in Items) //n times
      {
        if (item.Name == name)
        {
          Items.RemoveAt(Items.IndexOf(position)); // O(n) + O(n) => O(n)
        }
      }
      // => O(n * n)
    }
