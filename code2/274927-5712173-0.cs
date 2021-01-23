    public class Processor
    {
        /// <summary>
        /// Process a traditional collection.
        /// </summary>
        /// <param name="collection">The collection.</param>
        public void Process(ICollection<string> collection)
        {
            Process(item =>
                {
                    if (collection.Contains(item))
                        return false;
                    collection.Add(item);
                    return true;
                });
        }
        /// <summary>
        /// Process a concurrent collection.
        /// </summary>
        /// <param name="collection">The collection.</param>
        public void Process(IProducerConsumerCollection<string> collection)
        {
            Process(item => collection.TryAdd(item));
        }
        /// <summary>
        /// Common processing.
        /// </summary>
        /// <param name="addFunc">A func to add the item to a collection</param>
        private void Process(Func<string, bool> addFunc)
        {
            var item = "new item";
            if (!addFunc(item))
                throw new InvalidOperationException("duplicate item");
        }
    }
