    static void PrintTree(Ancestor ancestor)
    {
        Stack<Tuple<int, Person>> PersonStack = new Stack<Tuple<int, Person>>();
        PersonStack.Push(new Tuple<int, Person>(0, ancestor));
        while (PersonStack.Count != 0)
        {
            Tuple<int, Person> NextPerson = PersonStack.Pop();
            Console.WriteLine(new string(' ', NextPerson.Item1) + NextPerson.Item2.Name);
            Parent NextPersonAsParent = NextPerson.Item2 as Parent;
            if (NextPersonAsParent != null && NextPersonAsParent.Children != null)
            {
                foreach (var Child in NextPersonAsParent.Children)
                {
                    PersonStack.Push(new Tuple<int, Person>(NextPerson.Item1 + 1, Child));
                }
            }
        }
    }
