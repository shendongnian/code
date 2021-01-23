     public class Node
     {
        private string _Parent = string.Empty;
        private string _Child = string.Empty;
        private bool   _IsRoot = false;
        public string Parent
        {
            set { _Parent = value; }
            get { return _Parent; }
        }
        public string Child
        {
            set { _Child = value; }
            get { return _Child; }
        }
        public Node(string PChild, string PParent)
        {
            _Parent = PParent;
            _Child = PChild;
        }
        public bool IsRoot
        {
            set { _IsRoot = value; }
            get { return _IsRoot; }
        }
     }
