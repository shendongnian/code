    public interface IDirty
    {
        bool IsDirty { get; }
    }   // eo interface IDirty
    public class SomeObject : IDirty
    {
        private string name_;
        private bool dirty_;
        public string Name
        {
            get { return name_; }
            set { name_ = value; dirty_ = true; }
        }
        public bool IsDirty { get { return dirty_; } }
    }   // eo class SomeObject
    public class SomeObjectWithChildren : IDirty
    {
        private int averageGrades_;
        private bool dirty_;
        private List<IDirty> children_ = new List<IDirty>();
        public bool IsDirty
        {
            get
            {
                bool ret = dirty_;
                foreach (IDirty child in children_)
                    dirty_ |= child.IsDirty;
                return ret;
            }
        }
    }   // eo class SomeObjectWithChildren
