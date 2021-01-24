    public class AClass
    {
        private void B()
        {
        }
        private void C()
        {
        }
        private void D()
        {
        }
        private bool Interceptor()
        {
            return false;
        }
        public void A()
        {
            var pipeline = new List<Action> { B, C, D };
            pipeline.Execute(Interceptor);
        }
    }
