    /// <summary>
    ///     Retrieves all descendants.
    /// </summary>
    public IEnumerable<Item> Descendants {
        get {
            // This performs a simple iterative preorder traversal.
            Stack<Item> stack = new Stack<Item>(this.Children);
            while (stack.Count > 0) {
                Itemcurrent = stack.Pop();
                yield return current;
    
                //Push current's children
                foreach (Item currentChild in current.Children) {
                    stack.Push(currentChild);
                }
            }
        }
    }
