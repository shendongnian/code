    List<int> indexesToRemove = new List<int>();
    for(int i = results.Count; i >= 0; i--)
    {
      if(someCondition)
      {
         //results.Remove(results[i]);
           indexesToRemove.Add(i);
      }
    }
    
    foreach(int i in indexesToRemove) {
    results.Remove(results[i]);
    }
