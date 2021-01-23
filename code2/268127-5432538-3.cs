    BasicClass[] notSelected = allCollection.Except(selectedCollection).ToArray();
    foreach(BasicClass item in notSelected)
    {
        selectedCollection.Add(item);
    }
