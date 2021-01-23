    Arraylist myList = new ArrayList();
    myList = someStuff;
    Dictionary<object, int> counts = new Dictionary<object,int>();
    foreach (object item in myList)
    {
        if (!counts.ContainsKey(item))
        {
           counts.Add(item,1);
        }
        else
        {
           counts[item]++;
        }
    }
