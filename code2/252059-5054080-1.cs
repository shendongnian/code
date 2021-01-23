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
            var child = new TreeNode(hex,meaning);
            // add logic to check that each child
            // has a unique hex
            _children.Add(child);
            return child;
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
            IList<string> msgs = getMessagesByPath(hexPath, new List<string>(), this);
            return
                (msgs == null || msgs.Count==0) ?
                    "None":
                    msgs.Aggregate((s1, s2) => s1 + ": " + s2);
        }
        
        // recursively follow the branch and read the node messages
        protected IList<string> getMessagesByPath(int hexPath, IList<string> accString, TreeNode curNode) 
        {
            char[] digits = hexPath.ToString("X").ToCharArray();
            if(digits.Length == 0 || char.GetNumericValue(digits[0]) == 0 || curNode==null) 
                return accString;
            else   
            {
                var chd = curNode.GetChildByCode((int)char.GetNumericValue(digits[0]));                
                string meaning = (chd==null)? "not found": chd.meaning;
                accString.Add(meaning);
                if(digits.Length==1) return accString;
                int newPath = Convert.ToInt32((new string(digits)).Substring(1),16);
                return getMessagesByPath(newPath,accString,chd);
            }
        }
    }
