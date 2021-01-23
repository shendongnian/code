        for (int i = 0; i < nameList.Count; i++)
            {
              if (nameList[i].IndexOf(name, 0, StringComparison.OrdinalIgnoreCase) != -1) 
                {
                    TempList.Add(nameList[i]);
                }
            }
