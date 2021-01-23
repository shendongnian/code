    public BinaryTreeNode Find(int e, bool throwIfNotFound)
            {
                var iterativenode = this._root;
                while(iterativenode != null)
                {
                    if(iterativenode.Element == e)
                    {
                        return iterativenode;
                    }
                    if(e < iterativenode.Element)
                    {
                        iterativenode = iterativenode.Left;
                    }
                    if(e > iterativenode.Element)
                    {
                        iterativenode = iterativenode.Right;
                    }
                }
                if(throwIfNotFound)
                {
                    throw new Exception(string.Format("Given element {0} is not found", e);
                }
                return null;
            }
