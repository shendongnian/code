    var myCollection = new List<double[]>();
    myCollection.Add(new double[]{1,2,3,4,5});
    myCollection.Add(new double[]{3,4,5,6,7});
    var qry = (from col in Enumerable.Range(0, myCollection.Min(arr => arr.Length))
               select myCollection.Average(arr => arr[col])).ToList();
