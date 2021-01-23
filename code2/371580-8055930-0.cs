    public static object[] MultiToSingle(object[,] multiArray)
    {
       List<string> tempList;
       object[] returnArray;
       tempList = new List<string>();
       //Add each element of the multi-dimensional Array to the list
       foreach (object oneObj in multiArray)
       {
          tempList.Add(oneObj.ToString());
       }
       //Convert the list to a single dimensional array
       returnArray = tempList.ToArray();
       return returnArray;
    }
