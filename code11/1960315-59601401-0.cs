     public List<string> getInfo()
        {
           var result= new List<string>();
            foreach (Member item in members)
            {
              result.Add(item.getName());
            }
            return result;
        }
