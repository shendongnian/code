    List<string> AddDashesToList(List<string> list)
    {
        if(list.Count > 1)
        { 
            var newList = new List<string>();
    
            foreach(item in list)
            {
               newList.Add(item);
               newList.Add("-");
            }
        
            if(newList.Count > 1)
            newList.RemoveAt(newList.Count-1);
            return newList;
        }
        else
        {
             return list;
        }
    }
