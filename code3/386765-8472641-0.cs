    void PrintFamily(Ancestor a)
    {
        Action<Parent, int> printParent = null;
        printParent = (parent, level) => 
        {
            var indentation = Enumerable.Repeat("    ", level).Aggregate ("", (s1, s2) => s1+s2);
            var indentationChildren = Enumerable.Repeat("    ", level + 1).Aggregate ("", (s1, s2) => s1+s2);
            Console.WriteLine(indentation + parent.Name);
            foreach(var child in parent.Children)
            {
                if(child is Child)
                    Console.WriteLine(indentationChildren + child.Name);
                else if(child is Parent)
                {
                    printParent((Parent)child, level + 1);
                }
            }
        };
        
        printParent(a, 0);
    }
