    for (int j = 0; j < listOfSmtObjects.Count(); j++)
    {
      for (int k = 0; k < listOfSmtObjects[j].Count(); k++)
      {
          if (listOfSmtObjects[j].ElementAt(k) != null)
          {
              if (listOfSmtObjectsTemp[j] == null)
              {
                  listOfSmtObjectsTemp[j] = new LinkedList<SMTObjects>();
              }
                  listOfSmtObjectsTemp[j].AddLast(listOfSmtObjects[j].ElementAt(k));
                            
           }
       }
    }
