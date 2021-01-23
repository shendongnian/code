    string name = null; // You need to set a value in case the collection is empty
    foreach (string loopName in names)
    {
        if (someCondition.IsTrueFor(loopName)
        {
            name = loopName;
            break;
        }
    }
