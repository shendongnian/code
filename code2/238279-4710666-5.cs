    public class MyEvilPlans {
        public void WreakHavoc<int>(int nodeData) {
            Console.WriteLine("The secret to life is:  {0}", nodeData.ToString());
        }
        public void PlayWithTree() {
            NTree<int> tree = new NTree<int>();
            //  Initialize tree
            //  If the tree has 47 nodes, WreakHavoc will be called 47 times,
            //  once for each node in the tree.
            tree.traverse(WreakHavoc);
        }
    
    }
