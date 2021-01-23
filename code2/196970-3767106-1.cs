    private void enumerateValues(IEnumerable<KeyValuePair<string, object>> items, TreeNode parentnode)
    {
      foreach (var item in items)
      {
        // Try a 'safe' cast of the current value.
        // If the cast fails, childEnumerator will be null.
        var childEnumerator = item.Value as IEnumerable<KeyValuePair<string, object>>;
        
        if (childEnumerator != null)
        {
          TreeNode childNode = parentnode.Nodes.Add(item.Key);
          
          enumerateValues(childEnumerator, childNode);
        }
        else
        {
          TreeNode childNode = parentnode.Nodes.Add(item.Value.ToString());
        }
      }
    }
