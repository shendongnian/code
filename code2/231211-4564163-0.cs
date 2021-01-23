    Arraylist myList = new ArrayList();
    myList = someStuff;
    myList.Sort();
    Object tempObject;
    Dictionary<object, int> counts = new Dictionary<object,int>();
    foreach (object item in myList)
    {
        if (tempObject = null || !tempObject.Equals(item))
        {
           tempObject = item;
           counts.Add(item,1);
        }
        else if (tempObject.Equals(item))
        {
           counts[tempObject]++;
        }
    }
