    public IEnumerable<Node> GetAllParents(IEnumerable<Node> records)
    {
            if (this.ParentID == 0)
            {
                // Reach the parent, so create the instance of the collection and brake recursive.
                return new List<Node>();
            }
    
            var parent = records.First(p => p.ID == ParentID);
    
            // create a collection from one item to concat it with the all parents.
            IEnumerable<Node> lst = new Node[] { parent };
    
            lst = lst.Concat(parent.GetAllParents(records));
    
            return lst;
    }
