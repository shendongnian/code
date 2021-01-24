    class Program
    {
        static void Main(string[] args)
        {
            BSTree<int> testTree = new BSTree<int>();
            //testTree.InsertItem(6);
            //testTree.InsertItem(12);
            //testTree.InsertItem(1);
            //testTree.Print();
            //Console.WriteLine();
            //testTree.RemoveItem(12);
            //testTree.Print();
            //Console.WriteLine();
            List<int> ls = new List<int> { 10, 5, 19, 1, 6, 17, 21, 9 };
            foreach (int i in ls)
                testTree.InsertItem(i);
            testTree.Print();
            Console.WriteLine();
            testTree.RemoveItem(6);
            testTree.Print();
            Console.WriteLine();
            Console.Read();
        }
    }
    class BinTree<T> where T : IComparable
    {
        protected Item<T> root;
        public BinTree()
        {
            root = null;
        }
        public BinTree(Item<T> item)
        {
            root = item;
        }
    }
    class Item<T> where T : IComparable
    {
        public Item<T> Left, Right, Parent;
        public Item(T item)
        {
            Data = item;
            Left = null;
            Right = null;
        }
        public T Data { set; get; }
    }
    class BSTree<T> : BinTree<T> where T : IComparable
    {
        public BSTree()
        {
            root = null;
        }
        public void InsertItem(T item)
        {
            Item<T> tmp = root;
            Item<T> par = tmp;
            while (tmp != null)
            {
                par = tmp;
                if (tmp.Data.CompareTo(item) == 0)
                {
                    Console.WriteLine($"Element {item} already exist\n");
                    return;
                }
                else if (tmp.Data.CompareTo(item) > 0)
                    tmp = tmp.Left;
                else
                    tmp = tmp.Right;
            }
            tmp = new Item<T>(item);
            if (par == null)
            {
                tmp.Parent = tmp;
                root = tmp;
            }
            else
            {
                tmp.Parent = par;
                if (item.CompareTo(par.Data) < 0)
                    par.Left = tmp;
                else
                    par.Right = tmp;
            }
        }
        public void RemoveItem(T item)
        {
            Item<T> theItem = Find(item);
            RemoveItem(theItem);
        }
        private Item<T> Find(T value)
        {
            Item<T> tmp = root;
            while (tmp != null)
            {
                if (value.CompareTo(tmp.Data) == 0)
                    return tmp;
                else if (value.CompareTo(tmp.Data) < 0)
                    tmp = tmp.Left;
                else
                    tmp = tmp.Right;
            }
            return null;
        }
        private void RemoveItem(Item<T> item)
        {
            if (item == null)
                return;
            if (item.Left == null && item.Right == null)
            {
                #region Remove leaf
                if (item == root)
                    root = null;
                else
                {
                    Item<T> par = item.Parent;
                    if (par.Left == item)
                        par.Left = null;
                    else
                        par.Right = null;
                }
                #endregion
            }
            else if (item.Left == null || item.Right == null)
            {
                #region Remove item with one child
                bool isroot = item == root;
                var par = item.Parent;
                var newchild = item.Left ?? item.Right;
                newchild.Parent = par;
                if (par.Left == item)
                    par.Left = newchild;
                else
                    par.Right = newchild;
                if (isroot)
                    root = newchild;
                #endregion
            }
            else
            {
                #region Remove item with two children
                Item<T> repl = Max(item.Left);
                item.Data = repl.Data;
                RemoveItem(repl);
                #endregion
            }
        }
        private Item<T> Max(Item<T> node)
        {
            Item<T> tmp = node;
            Item<T> ret = node;
            while (tmp != null)
            {
                ret = tmp;
                tmp = tmp.Right;
            }
            return ret;
        }
        public void Print(Item<T> node = null) => _print(node ?? root);
        private void _print(Item<T> node)
        {
            if (node != null)
            {
                _print(node.Left);
                Console.Write(node.Data + " ");
                _print(node.Right);
            }
        }
    }
