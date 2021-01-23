    public abstract class BaseClass
    {
        private string m_name;
        public string Name
        {
            get { return m_name; }
            set
            {
                if (BeforeNameSet(value))
                    m_name = value;
            }
        }
        public virtual bool BeforeNameSet(string name)
        {
            return true;
        }
    }
    public abstract class ChildClass : BaseClass
    {
        public override bool BeforeNameSet(string name)
        {
            // do the part that is different
            return false;
        }
    }
