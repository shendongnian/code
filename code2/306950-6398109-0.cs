    Try this out..  
    
      string[] things = new string[] { "paul", "bob", "lauren", "007", "90", "-10" };
            List<int> num = new List<int>();
            List<string> str = new List<string>();
            for (int i = 0; i < things.Count(); i++)
            {
                int result;
                if (int.TryParse(things[i], out result))
                {
                    num.Add(result);
                }
                else
                {
                    str.Add(things[i]);
                }
            
            }
