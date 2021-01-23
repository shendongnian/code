    public class NodeLevel
    {
        public TreeNode Node { get; set;}
        public int Level { get; set;}
    }
    
    public class NodeLevelList
    {
        private Dictionary<int,List<TreeNode>> finalLists = new Dictionary<int,List<TreeNode>>();
        
        public void AddToDictionary(NodeLevel ndlvl)
        {
            if(finalLists.ContainsKey(ndlvl.Level))
            {
                finalLists[ndlvl.Level].Add(ndlvl.Node);
            }
            else
            {
                finalLists.Add(ndlvl.Level,new List<TreeNode>(){ndlvl.Node});
            }
        }
        
        public Dictionary<int,List<TreeNode>> GetFinalList()
        {
            return finalLists;
        }
    }
