    int checkID = 0;
    while (checkID < MyList.Count)
    {
     string szCheckItem = MyList[checkID];
     string []Pairs = szCheckItem.Split("-".ToCharArray());
     string szInvertItem = Pairs[1] + "-" + Pairs[0];
     int i=checkID+1;
     while (i < MyList.Count)
     {
      if((MyList[i] == szCheckItem) || (MyList[i] == szInvertItem))
      {
       MyList.RemoveAt(i);
       continue;
      }
      i++;
     }
     
     checkID++;
    }
