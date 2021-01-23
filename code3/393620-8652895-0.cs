          IDictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
          if (!dictionary.ContainsKey(key))
          {
              dictionary.Add(key, new List<string>());
          }
          dictionary[key].Add(value);
