    void LoopThruLinkedList(params LinkedList<string>[] strLists)
    {
       var max = strLists.Max(x => x.Count());
    
       for (int i = 0; i < max; i++)
       {
          foreach (var item in strLists)
             Console.Write($"{(item.Count> i?item.ElementAt(i):""),-20}");
          Console.WriteLine();
       }
    }
    
    // Creating a linkedlist
    // Using LinkedList class
    LinkedList<string> my_list = new LinkedList<string>();
    
    // Adding elements in the LinkedList
    // Using AddLast() method
    my_list.AddLast("Zoya");
    my_list.AddLast("Shilpa");
    my_list.AddLast("Rohit");
    my_list.AddLast("Rohan");
    my_list.AddLast("Juhi");
    my_list.AddLast("Zoya");
    my_list.AddLast("Rohit");
    
    string List1 = "List One Students: ";
    string List2 = "List Two Students: ";
    string List3 = "List Three Students: ";
    
    Console.WriteLine($"{List1,-20}{List2,-20}{List3,-20}");
    
    
    // Accessing the elements of LinkedList using the foreach loop
    LoopThruLinkedList(my_list, my_list, my_list);
