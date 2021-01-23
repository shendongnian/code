    public class wrappedInt: IWrapper<int>
    {
        private WrapperCollection<wrappedInt, int> list;
        public Model { get; private set; }
        public wrappedInt(int source, WrapperCollection<wrappedInt, int> list)
        {
            this.Model = source;
            this.list = list;
        }
        public void RemoveMe()
        {
            if (list != null)
            {
                list.Remove(this);
                list = null;
            }
        }
    }
