     List<List1> result = new List<List1>();
     foreach (var listItem in list2)
        {
          var list1Obj = list1.Where(n => listItem.ListInfo.Any(x => x.StudentCode == n.StudentCode)).FirstOrDefault();
          if(list1Obj != null)
             result.Add(list1Obj);
        }
