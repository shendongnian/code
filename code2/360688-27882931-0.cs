    class commonParent
    {
        protected string name;
    
        protected static string GetName(commonParent other)
        {
            return other.name;
        }
    }
    
    class child1 : commonParent
    {
        // do some stuff
    }
    
    class child2 : commonParent
    {
        protected void test()
        {
            child1 myChild1 = new child1();
            string oldName = commonParent.GetName(myChild1);
    
        }
    }
