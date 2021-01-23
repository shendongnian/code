        public UGTreeNodeCollection(TreeNodeCollection TreeNodeCollectionItem)
        {
            NodeCollection = TreeNodeCollectionItem;
        }
        private TreeNodeCollection NodeCollection;
        public TreeNode Add(string text)
        {
            return NodeCollection.Add(text);
        }
        public int Add(TreeNode node)
        {
            return NodeCollection.Add(node);
        }
        public TreeNode Add(string key, string text)
        {
            return NodeCollection.Add(key, text) as TreeNode;
        }
        public TreeNode Add(string key, string text, int imageIndex)
        {
            return NodeCollection.Add(key, text, imageIndex);
        }
        public TreeNode Add(string key, string text, string imageKey)
        {
            return NodeCollection.Add(key, text, imageKey);
        }
        public TreeNode Add(string key, string text, int imageIndex, int selectedImageIndex)
        {
            return NodeCollection.Add(key, text, imageIndex, selectedImageIndex);
        }
        public TreeNode Add(string key, string text, string imageKey, string selectedImageKey)
        {
            return NodeCollection.Add(key, text, imageKey, selectedImageKey);
        }
        public void AddRange(TreeNode[] nodes)
        {
            NodeCollection.AddRange(nodes);
        }
        public ParallelQuery AsParallel()
        {
            return NodeCollection.AsParallel();
        }
        public IQueryable AsQueryable()
        {
            return NodeCollection.AsQueryable();
        }
        public IEnumerable<TResult> Cast<TResult>()
        {
            return NodeCollection.Cast<TResult>();
        }
        public void Clear()
        {
            NodeCollection.Clear();
        }
        public bool Contains(TreeNode node)
        {
            return NodeCollection.Contains(node);
        }
        public bool ContainsKey(string key)
        {
            return NodeCollection.ContainsKey(key);
        }
        public void CopyTo(Array dest, int index)
        {
            NodeCollection.CopyTo(dest, index);
        }
        public int Count
        {
            get
            {
                return NodeCollection.Count;
            }
            private set { }
        }
        public bool Equals(object obj)
        {
            return NodeCollection.Equals(obj);
        }
        public TreeNode[] Finde(string key, bool searchAllChildren)
        {
            return NodeCollection.Find(key, searchAllChildren);
        }
        public IEnumerator GetEnumerator()
        {
            return NodeCollection.GetEnumerator();
        }
        public int GetHashCode()
        {
            return NodeCollection.GetHashCode();
        }
        public Type GetType()
        {
            return NodeCollection.GetType();
        }
        public int IndexOf(TreeNode node)
        {
            return NodeCollection.IndexOf(node);
        }
        public int IndexOfKey(string key)
        {
            return NodeCollection.IndexOfKey(key);
        }
        public TreeNode Insert(int index, string text)
        {
            return NodeCollection.Insert(index, text);
        }
        public void Insert(int index, TreeNode node)
        {
            NodeCollection.Insert(index, node);
        }
        public TreeNode Insert(int index,string key, string text)
        {
            return NodeCollection.Insert(index, key, text);
        }
        public TreeNode Insert(int index, string key, string text,int imageIndex)
        {
            return NodeCollection.Insert(index, key, text, imageIndex);
        }
        public TreeNode Insert(int index, string key, string text, string imageKey)
        {
            return NodeCollection.Insert(index, key, text, imageKey);
        }
        public TreeNode Insert(int index, string key, string text, int imageIndex, int selectedImageIndex)
        {
            return NodeCollection.Insert(index, key, text, imageIndex, selectedImageIndex);
        }
        public TreeNode Insert(int index, string key, string text, string imageKey, string selectedImageKey)
        {
            return NodeCollection.Insert(index, key, text, imageKey, selectedImageKey);
        }
        public bool IsReadyOnly
        {
            get
            {
                return NodeCollection.IsReadOnly;
            }
            private set
            {
            }
        }
        public IEnumerable<TResult> OfType<TResult>()
        {
            return NodeCollection.OfType<TResult>();
        }
        public void Remove(TreeNode node)
        {
            NodeCollection.Remove(node);
        }
        public void RemoveAt(int index)
        {
            NodeCollection.RemoveAt(index);
        }
        public void RemoveByKey(string key)
        {
            NodeCollection.RemoveByKey(key);
        }
        public string ToString()
        {
            return NodeCollection.ToString();
        }
    }
