        private Node FindMinRecHelper(Node current)
        {
            if (current.LeftNode == null)
            {
                return current;
            }
            else
            {
                return FindMinRecHelper(current.LeftNode);
            }
        }
        public void FindMinRec()
        {
            Node current = FindMinRecHelper(root);
            Console.WriteLine(current.Data);
        }
