    List<List<MyOtherClass>> innerLists = new List<List<MyOtherClass>>();
    for (int i = 0; i < myOuterList.Count; i++)
    {
        innerLists.Add(myOuterList[i].myInnerList);
    }
