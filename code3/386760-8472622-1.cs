    static void Write(Ancestor root)
    {
        // stack since depth-first
        var stack = new Stack<Tuple<Person,int>>();
        stack.Push(Tuple.Create((Person)root, 0));
        while(stack.Count > 0)
        {
            var pair= stack.Pop();
            var person = pair.Item1;
            // indentation
            Console.Write(new string('\t', pair.Item2));
            Parent parent = person as Parent;
            // node markers aren't fully specified, but this gets somewhere
            // near; maybe * should actually be checking Children != null &&
            // Children.Count > 0             
            if(person == root) {}
            else if (parent != null) { Console.Write("*");}
            else {Console.Write("-");}            
            
            Console.WriteLine(person.Name);
            
            // recursion on the stack
            if(parent != null && parent.Children != null) {
                foreach(var next in Enumerable.Reverse(parent.Children)) {
                    stack.Push(Tuple.Create(next, pair.Item2 + 1));
                }
            }
        }
    }
