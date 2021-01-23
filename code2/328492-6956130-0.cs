    using System.Linq;
    …
    if (myList.Any()) // we need to distinguish between empty and non-empty lists 
    {
        var value = myList.First().MyMember;
        return myList.All(item => item.MyMember == value);
    }
    else
    {
        return true;  // or false, if that is more appropriate for an empty list    
    }
