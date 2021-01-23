    private void enumerateValues(IEnumerator<KeyValuePair<string, object>> iEnumerator, TreeNode parentnode)
    {
      // Loop through the values.
      while (iEnumerator.MoveNext())
      {
        // Try a 'safe' cast of the current value.
        // If the cast fails, childEnumerator will be null.
        var childEnumerator = iEnumerator.Current.Value as IEnumerator<KeyValuePair<string, object>>;
        
        if (childEnumerator != null)
        {
          TreeNode childNode = parentnode.Nodes.Add(iEnumerator.Current.Key);
          
          enumerateValues(childEnumerator, childNode);
        }
        else
        {
          TreeNode childNode = parentnode.Nodes.Add(iEnumerator.Current.Value.ToString());
        }
      }
    }
