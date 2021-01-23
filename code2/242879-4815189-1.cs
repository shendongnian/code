    public IEnumerable<Node> GetAllParents(IEnumerable<Node> records)
    {
            if (this.ParentID == 0)
            {
                // Reach the parent, so create the instance of the collection and brake recursive.
                return new List<Node>();
            }
    
            var parent = records.Where(p => p.ID == ParentID);
            var parents = parent.Concat(parent.GetAllParents(records));
    
            return parent;
    }
