    public static int NodeDepth(int node, Dictionary<int,int> parents)
    {
         int depth = 0;
         while (parents.ContainsKey(node))
         {
              node = parents[node];
              depth++;
         }
         return depth;
    }
