        private static void PrintAncestor(Ancestor myAncestor)
        {
            Console.WriteLine(myAncestor.Name);
            foreach (var child in myAncestor.Children)
            {
                string intend = new string(myAncestor.Name.TakeWhile(c => c == '\t').ToArray()) + '\t';
                if (child is Ancestor)
                    PrintAncestor(new Ancestor {
                        Children = (child as Ancestor).Children,
                        Name = intend + child.Name
                    });
                if (child is Parent)
                    PrintAncestor(new Ancestor {
                        Children = (child as Parent).Children,
                        Name = intend + "- *" + child.Name
                    });
                if (child is Child)
                    Console.WriteLine(intend + "-  " + child.Name);
            }
        }
