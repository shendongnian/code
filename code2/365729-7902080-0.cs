    public abstract class ResourceList<TYPE> where TYPE : BaseResource // change to your actual base-class or interface
    {
        private Dictionary<string, TYPE> resources_ = new Dictionary<string, TYPE>();
        // loader
        protected abstract TYPE LoadImpl(string name);
        public TYPE this[string name]
        {
            get
            {
                TYPE resource;
                if(!resources_.ContainsKey(name))
                {
                    resource = LoadImpl();
                    resources_[name] = resource;
                }
                else
                    resource = resources_[name];
                return resource;
            }
        }
    } // eo class ResourceList
