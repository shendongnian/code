    public class ChildrenSet : ISet<Child>
    {
        private HashSet<Child> backing = new HashSet<Child>();
        private Parent parent;
        internal ChildrenSet(Parent p)
        {
            this.parent = p;
        }
        public bool Add(Child item)
        {
            if(backing.Add(item))
            {
                item.Parent = this.parent;
                return true;
            }
            return false;
        }
        public bool Remove(Child item)
        {
            if(backing.Remove(item))
            {
                item.Parent = null;
                return true;
            }
            return false;
        }
        // etc for the rest of ISet. Also GetEnumerator, if desired.
    }
