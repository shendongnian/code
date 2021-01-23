    List<List<double>> t = new List<List<double>>();
    //adding test data
    t.Add(new List<double>() { 12343, 345, 3, 23, 2, 1 });
    t.Add(new List<double>() { 43, 123, 3, 54, 233, 1 });
    //creating target
    List<List<float>> q;
    //conversion
    q = t.ConvertAll<List<float>>(
            (List<double> inList) => 
            {
                return inList.ConvertAll<float>((double inValue) => { return (float)inValue; });
            }
         );
