    class Item
    {
        public virtual bool IsSame(Item comp){ return comp.Name == Name; }
    }
    
    class Tool: Item
    {
        public override bool IsSame(Item comp)
        {
            return base.IsSame(comp) && (comp is Tool) && ((Tool)comp).Material == Material && ((Tool)comp).Classification == Classification;
        }
    }
