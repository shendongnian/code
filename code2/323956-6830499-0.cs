    var i=test.FirstOrDefault();
    if (i==null) {
      // NO ITEMS IN LIST!!!
      // So do something else!
    }
    var type=i.GetType();
    var aGetter=type.GetProperty("a");
    var bGetter=type.GetProperty("b");
    foreach (var item in test) {
      bool myA = (bool)aGetter.GetValue(item,null);
      int myB=(int)bGetter.GetValue(item.null);
    }
