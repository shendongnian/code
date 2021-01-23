    public BinaryTreeNode LeastCommonAncestor(int e1, int e2)
            {
                //ensure both elements are there in the bst
                var n1 = this.Find(e1, throwIfNotFound: true);
                if(e1 == e2)
                {
                    return n1;
                }
                if(e2 != e1)
                {
                    this.Find(e2, throwIfNotFound: true);
                }
                BinaryTreeNode leastCommonAcncestor = this._root;
                var iterativeNode = this._root;
                while(iterativeNode != null)
                {
                    if((iterativeNode.Element > e1 ) && (iterativeNode.Element > e2))
                    {
                        iterativeNode = iterativeNode.Right;
                    }
                    else if(iterativeNode.Element < e1 && iterativeNode.Element < e2)
                    {
                        iterativeNode = iterativeNode.Left;
                    }
                    else
                    {
                        //i.e; either iterative node is equal to e1 or e2 or in between e1 and e2
                        return iterativeNode;
                    }
                }
                //control will never come here
                return leastCommonAcncestor;
            }
