    List<string> testList = new List<string> {
        "Search",
        "1",
        "2",
        "3",
        "4",
        null                
        };
    double num;
    int maxNumeric = testList.Where(x => double.TryParse(x, out num)).Select(x => Convert.ToInt32(x)).Max();
