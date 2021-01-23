    static void PrintTree(Ancestor ancestor)
    {
        Queue<Tuple<int, Person>> PersonQueue = new Queue<Tuple<int, Person>>();
        PersonQueue.Enqueue(new Tuple<int, Person>(0, ancestor));
        while (PersonQueue.Count != 0)
        {
            Tuple<int, Person> NextPerson = PersonQueue.Dequeue();
            Console.WriteLine(new string(' ', NextPerson.Item1) + NextPerson.Item2.Name);
            Parent NextPersonAsParent = NextPerson.Item2 as Parent;
            if (NextPersonAsParent != null && NextPersonAsParent.Children != null)
            {
                foreach (var Child in NextPersonAsParent.Children)
                {
                    PersonQueue.Enqueue(new Tuple<int, Person>(NextPerson.Item1 + 1, Child));
                }
            }
        }
    }
