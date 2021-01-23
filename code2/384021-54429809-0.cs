    public int Height()
        {
            int result = GetMaxHeight(this.Root,0);
            return result;
        }
        private int GetMaxHeight(Node<T> node,int count)
        {
            int leftMax = 0, rightMax = 0;
            if (node.Left != null)
            {
                leftMax = GetMaxHeight(node.Left, count+1);
            }
            if (node.Right != null)
            {
                rightMax = GetMaxHeight(node.Right, count + 1);
            }
            if(node.Left==null && node.Right == null)
            {
                return count;
            }
            return Math.Max(leftMax,rightMax);
        }
