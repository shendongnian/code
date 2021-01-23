    [TestMethod]
            public void LeastCommonAncestorTests()
            {
                int[] a = { 13, 2, 18, 1, 5, 17, 20, 3, 6, 16, 21, 4, 14, 15, 25, 22, 24 };
                int[] b = { 13, 13, 13, 2, 13, 18, 13, 5, 13, 18, 13, 13, 14, 18, 25, 22};
                BinarySearchTree bst = new BinarySearchTree();
                foreach (int e in a)
                {
                    bst.Add(e);
                    bst.Delete(e);
                    bst.Add(e);
                }
                for(int i = 0; i < b.Length; i++)
                {
                    var n = bst.BstLeastCommonAncestor(a[i], a[i + 1]);
                    Assert.IsTrue(n.Element == b[i]);
                }
            }
