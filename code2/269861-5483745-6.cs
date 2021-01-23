    Func<MyObject, object> fieldGetter;
    // Option A, switch
    switch (whatField) {
       case "FieldA": fieldGetter = o => o.FieldA; break;
       case "FieldB": fieldGetter = o => o.FieldB; break;
       // More options
    }
   
    // Option B using reflection:
    var t = typeof(MyObject);
    var prop = t.GetProperty(whatField);
    fieldGetter = o => prop.GetValue(o, null);
    // Linq then looks like
    var result = (from p in MyListObject 
         where p.FieldA == "Test" 
         select fieldGetter(p));
