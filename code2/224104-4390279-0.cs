    using System.Linq;
    var theCollectionImWorkingOn = ...
    var firstItem = theCollectionImWorkingOn.First();
    firstItem.DoSomeWork();
    foreach(var item in theCollectionImWorkingOn.Skip(1))
    {
        item.DoSomeOtherWork();
    }
