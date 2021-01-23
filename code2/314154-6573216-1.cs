    List<string> testList = new List<string> {
        "Search",
        "1",
        "2",
        "3",
        "4",
        null                
        };
    int num;
    int maxNumeric = testList.Where(x => int32.TryParse(x, out num)).Select(x => Convert.ToInt32(x)).Max();
