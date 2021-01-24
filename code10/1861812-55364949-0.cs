        public static void PrintTree2(Node tree)
        {
            Stack<Node> stack = new Stack<Node>();
            Stack<int> nodeLevel = new Stack<int>();
            stack.Push(tree);
            nodeLevel.Push(1);
            
            while (stack.Count > 0)
            {
                Node next = stack.Pop();
                int curLevel = nodeLevel.Pop();
                Console.WriteLine(curLevel + " " + next.Name);
                foreach (Node c in next.Children)
                {
                    nodeLevel.Push(curLevel + 1);
                    stack.Push(c);
                }
            }
        }
