    public class SameTest<T>
    {
        public bool TestCircularArray(IEnumerable<T> array1, IEnumerable<T> array2)
        {
            if (array1 == null)
                throw new ArgumentNullException("array1");
            if (array2 == null)
                throw new ArgumentNullException("array2");
    
            // if they are the same, the length must be the same
            if (array1.Count() != array2.Count())
                return false;
    
            // two empty array assume to same
            if (!array1.Any())
                return true;
    
            // convert array2 to linkedlist
            var linkedList = new LinkedList<T>(array2);
    
            LinkedListNode<T> node = null;
    
            foreach (T item1 in array1)
            {
                // first find the element in link
                if (node == null)
                {
                    node = linkedList.Find(item1);
                    if (node == null)
                        return false;
                    continue;
                }
    
                node = node.Next;
                // reach tail move to head
                if (node == null)
                    node = linkedList.First;
    
                if (!item1.Equals(node.Value))
                    return false;
            }
    
    
            return true;
        }
    }
    
    [TestMethod]
    public void TestMethod1()
    {
        int[] array1 = {2, 3, 1};
        int[] array2 = {1, 2, 3};
        int[] array3 = {2, 1, 3};
    
        var tester = new SameTest<int>();
    
        var result = tester.TestCircularArray(array1, array2);
    
        Assert.AreEqual(true, result);
    
        result = tester.TestCircularArray(array2, array3);
    
        Assert.AreEqual(false, result);
    }
