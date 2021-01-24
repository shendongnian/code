    public class Demo
    {
        private int Value;
        private List<Action> Operations = new List<Action>();
        public Demo Get(int a)
        {
            this.Operations.Add(() => this.Value = a);
            return this;
        }
        public Demo Update(int a)
        {
            this.Operations.Add(() => this.Value += a);
            return this;
        }
        public bool CatchError()
        {
            foreach (var operation in Operations)
            {
                try
                {
                    operation();
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            Operations.Clear();
            return true;
        }
    }
