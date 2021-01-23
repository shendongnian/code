    List<Cat> cats = new List<Cat>();
    foreach(Cat cat in listOfCats)
    {
        if (cat.Age > 5)
        {
            if (cat.Color == "White")
            {
                cats.Add(cat);
            }
        }
    }
