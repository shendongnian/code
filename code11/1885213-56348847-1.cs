    public class TestClass
    {
        public Childclass root;
        public void Assign(Childclass root, int data)
        {
            if (root == null)
            {
                //over here
                this.root = new Childclass(data);
            }
        }
    }
