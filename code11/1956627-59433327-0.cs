void Start()
    {
        string SearchTerm = "museum"; //Example text 
        List<string> Museums = new List<string>() {
            "the aquarium",
            "the british museum",
            "the german museum",
            "natural history building",
            "glasgow science room"
        };
        if (Museums.Any(str => str.Contains(SearchTerm)))
        {
            Museums.ForEach(delegate(String museum)
            {
                if (museum.Contains(SearchTerm))
                {
                    print(museum)
                }
            });
        else
        {
            print("None found, search again");
        }
    }
