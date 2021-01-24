    public class AdSlotSizes : IEnumerable<int>, IEnumerable<string>
    {
        public enum CollectionType
        {
            Uninitialized,
            Integers,
            Strings,
        }
        private List<int> _integerSizes;
        private List<string> _stringSizes;
        public void Add(int sizeToAdd)
        {
            InitializeList(CollectionType.Integers);
            _integerSizes.Add(sizeToAdd);
        }
        public void Add(string sizeToAdd)
        {
            InitializeList(CollectionType.Strings);
            _stringSizes.Add(sizeToAdd);
        }
        public CollectionType SizesCollectionType => _collectionType;
        private CollectionType _collectionType = CollectionType.Uninitialized;
        private void InitializeList(CollectionType forCollectionType)
        {
            CollectionType oppositeCollectionType = (CollectionType)(((int) CollectionType.Strings + 1) - (int) forCollectionType);
            if (_collectionType == oppositeCollectionType)
            {
                throw new ArgumentException($"A single {nameof(AdSlotSizes)} instance can only hold one type of sizes (int or string)");
            }
            if (_collectionType != CollectionType.Uninitialized)
            {
                return;
            }
            _collectionType = forCollectionType;
            if (forCollectionType == CollectionType.Strings)
            {
                _stringSizes = _stringSizes ?? new List<string>();
            }
            if (forCollectionType == CollectionType.Integers)
            {
                _integerSizes = _integerSizes ?? new List<int>();
            }
        }
        public IEnumerable<int> GetIntegerSizes()
        {
            if (_collectionType != CollectionType.Integers)
            {
                throw new ArgumentException("Size collection not initialized for integers");
            }
            foreach (var size in _integerSizes)
            {
                yield return size;
            }
        }
        public IEnumerable<string> GetStringSizes()
        {
            if (_collectionType != CollectionType.Strings)
            {
                throw new ArgumentException("Size collection not initialized for strings");
            }
            foreach (var size in _stringSizes)
            {
                yield return size;
            }
        }
        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
