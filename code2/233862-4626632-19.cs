    static void Main(string[] args)
    {
        InitializeExampleGraph1();//or: InitializeExampleGraph2();
        Node.SetReferences();
        var allCycles = FindAllCycles().ToList();
    }
    static void InitializeExampleGraph1()
    {
        new Node(1, 2);//says that the first node(node a) links to b and c.
        new Node(2);//says that the second node(node b) links to c.
        new Node(0, 3);//says that the third node(node c) links to a and d.
        new Node(0);//etc
    }
    static void InitializeExampleGraph2()
    {
        new Node(1);
        new Node(0, 0, 2);
        new Node(0);
    }
