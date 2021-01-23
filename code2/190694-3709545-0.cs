    public IEnumerable<Spline> Descendants
    {
        get
        {
            // This performs a simple iterative preorder traversal.
            var stack = new Stack<Spline>(new Spline[] { this });
            while (stack.Count > 0)
            {
                Spline current = stack.Pop();
                yield return current;
                for (int i = current.ChildrenCount - 1; i >= 0; i--)
                {
                    stack.Push(current.GetChild(i));
                }
            }
        }
    }
