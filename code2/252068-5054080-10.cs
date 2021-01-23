    public class TreeNode
    {
        private List<TreeNode> _children;
    
        public int hex {get; private set;}
        public string meaning {get; private set;}
        public IList<TreeNode> children {
            get{
                return _children.AsReadOnly();
            }
        }
    
        public TreeNode(int hex, string meaning)
        {
            this.hex = hex;
            this.meaning = meaning;
            _children = new List<TreeNode>();
        }
    
        public TreeNode addChild(int hex, string meaning)
        {
            if(hex<=0 || hex >=16) throw new ArgumentOutOfRangeException("hex");
            if(GetChildByCode(hex)!=null) throw new Exception("a child with code " + 
                                                 hex.ToString() + " already exists");                   
            var child = new TreeNode(hex,meaning);
             _children.Add(child);
            return child;
        }
        
        public TreeNode TryAddChild(int hex, string meaning)
        {
            if(hex<=0 || hex >=16) throw new ArgumentOutOfRangeException("hex");
            var chd = GetChildByCode(hex);
            
            if(chd==null) { 
                chd = new TreeNode(hex,meaning);
                _children.Add(chd);
            }
            return chd;         
        }
        
        public void AddBranch(int hexPath, string[] meanings)
        {
            var lst = intToList(hexPath,16,new LinkedList<int>()).ToList();        
            var curNode = this;
            for(int i = 0; i<lst.Count; i++)
            {
                curNode = curNode.TryAddChild(lst[i], meanings[i]);             
            }                         
        }
    
        public TreeNode GetChildByCode(int hex)
        {
            return 
                (from c in _children
                where c.hex == hex
                select c).SingleOrDefault();          
        }
    
        public string getMessagesByPath(int hexPath)
        {            
            var lst = intToList(hexPath,16,new LinkedList<int>());
            var msgs = getMessagesByPath(lst, new List<string>(),this);
            return
                (msgs == null || msgs.Count==0) ?
                    "None":
                    msgs.Aggregate((s1, s2) => s1 + ": " + s2);
        }
    
    
        // recursively follow the branch and read the node messages
        protected IList<string> getMessagesByPath(LinkedList<int> hexPath, IList<string> accString, TreeNode curNode) 
        {
            if(hexPath.Count == 0 || hexPath.First.Value == 0 || curNode==null) 
                return accString;
            else   
            {
                var chd = curNode.GetChildByCode(hexPath.First.Value);                
                string meaning = (chd==null)? "not found": chd.meaning;
                accString.Add(meaning);
                hexPath.RemoveFirst();
                return getMessagesByPath(hexPath,accString,chd);
            }
        }
    
        // convert the code to a list of digits in the given base (in this case 16)
        // this could be an extension method for int      
        private LinkedList<int> intToList(int theInt, int theBase, LinkedList<int> acc)
        {
            if(theInt < theBase) 
            {
                acc.AddFirst(theInt);
                return acc;
            }
            else
            {
                acc.AddFirst(theInt % theBase);
                return intToList(theInt/theBase, theBase, acc);
            }
        }
    }
