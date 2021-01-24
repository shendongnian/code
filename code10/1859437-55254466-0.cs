    class ItemNode:TreeNode
    {
        internal private string _key = null;
        internal public string Key
        {
            get
            {
                if (_key == null) _key = base.FullPath.split("\\")[1];
                return _key;
            }
            set 
            {
                _key = value;
            }
         }
    }
