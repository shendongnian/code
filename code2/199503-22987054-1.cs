    static void Main(string[] args)
    {
        DynamicLinkedList list = new DynamicLinkedList();
        list.AddAtLastPosition(1);
        list.AddAtLastPosition(2);
        list.AddAtLastPosition(3);
        list.AddAtLastPosition(4);
        list.AddAtLastPosition(5);
        object lastElement = list.GetLastElement();
        Console.WriteLine(lastElement);
    }
