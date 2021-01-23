    public static class MyExtensions
    {
        public static Control FindById(this Page p, string id)
        {
            return FindControlRecursive(p, id);
        }
        
        private static Control FindByIdRecursive(Control root, string id)
        {
            if (root.ID == id)
                return root;
    
            foreach (Control c in root.Controls)
            {
                Control c2 = FindByIdRecursive(c, id);
                if (c2 != null)
                    return t;
            }
    
            return null;
        }
    
    }
