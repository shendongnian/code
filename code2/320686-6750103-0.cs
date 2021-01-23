    private static List<DistroHeader> getHeaders<T>(Func<IEnumerable<T>> getHeaders)
    {
        List<MyObj> myObj = new List<MyObj>();
        var result = from a in getMyObjData()
                     select a;
 
        var pi = new List<PropertyInfo>(typeof(T).GetProperties());
        foreach (var row in result)
        {
            myObj.Add(new MyObj()
            {
                Id = (int)pi.Find(x => x.Name == "id").GetValue(row, null),
                Description = (string)pi.Find(x => x.Name == "descr").GetValue(row, null),
                // ...etc      
            });
        }
    }
