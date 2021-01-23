                List<MyObject> currentList = new List<MyObject>();
                List<List<MyObject>> finalList = new List<List<MyObject>>();
                for (int i = 0; i < myObjects.Count; i++)
                {
                    //If the list is empty, or has the same LineId, add to it.
                    if (currentList.Count == 0 || currentList[0].LineId == myObjects[i].LineId)
                    {
                        currentList.Add(myObjects[i]);
                    }
                    //Otherwise, create a new list.
                    else
                    {
                        finalList.Add(currentList);
                        currentList = new List<MyObject>();
                        currentList.Add(myObjects[i]);
                    }
                }
                finalList.Add(currentList);
