    class Container
    {
        public Container() { Items = new Dictionary<int, Container>(); }
        public DateTime DateTime {get;set;}
        Dictionary<int, Container> Items {get;set;}
    }
    Dictionary<int, Container> items = new Dictionary<int, Container>();
    foreach (var date in theListCalledL)
    {
        Container yearContainer;
        if (!items.TryGetValue(date.Year, out yearContainer))
        {
            yearContainer = new Contanier{DateTime = date};
            items.Add(date.Year, yearContainer);
        }
        Container monthContainer;
        if (!yearContainer.Items.TryGetValue(date.Month, out monthContainer))
        {
            monthContainer = new Contanier{DateTime = date};
            yearContainer.Add(date.Month, monthContainer);
        }
        Container dayContainer;
        if (!monthContainer.Items.TryGetValue(date.Day, out dayContainer))
        {
            dayContainer = new Contanier{DateTime = date};
            monthContainer.Add(date.Day, dayContainer);
        }
    }
    //and to get items:
    var container = items[1997][8][10];
    Console.WriteLine("The date was: " + contanier.DateTime);
   
    var tmp = items[1997];
    Console.WriteLine("1997 has items for " + tmp.Items.Count + " months.");
