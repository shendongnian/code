    Dictionary<string, int> group10 = new Dictionary<string, int>();
    group10.Add("MATH", 30);
    Dictionary<string, int> group11 = new Dictionary<string, int>();
    group10.Add("MATH", 40);
    Dictionary<string, int> group9 = new Dictionary<string, int>();
    group10.Add("CHEM", 50);
    var group = new Dictionary<string, Dictionary<string, int>>();
    group.Add("10", group10);
    group.Add("11", group11);
    group.Add("9", group9);
    int v1 = group["10"]["MATH"]; // v1 = 30
    int v2 = group["11"]["MATH"]; // v2 = 40
    int v3 = group["9"]["CHEM"]; // v3 = 50
