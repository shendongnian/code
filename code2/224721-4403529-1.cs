       List<string> list1 = new List<string>() { "Test1", "Test1", "Test2", "Test2" };
       List<string> list2 = new List<string>() { "Test2" };
       for(int i=0;i<list1.Count;i++)
       {
           var s = list1[i];
           int index = list2.IndexOf(s);
           if(index >= 0)
           {
               list2.RemoveAt(index);
               list1.RemoveAt(i);
               i--;
           }
       }
       for (int i = 0; i < list2.Count; i++)
       {
           var s = list2[i];
           int index = list1.IndexOf(s);
           if (index >= 0)
           {
               list1.RemoveAt(index);
               list2.RemoveAt(i);
               i--;
           }
       }
       var newList = list1.Concat(list2);
