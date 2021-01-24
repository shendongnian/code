    public class Box
    {
        private Apple[] _apples;
    
        public IEnumerable<Apple> Apples
        {
            get
            {
                return _apples.Clone() as Apple[];
            }
        }
    
        public Box(int maxPositions)
        {
            _apples = new Apple[maxPositions];
        }
    
        public void RemoveApple(Apple apple)
        {
            var position = GetApplePosition(apple);
            if (position > -1)
            {
                _apples[position] = null;
                apple.MoveToHand();
            }
        }
    
        public int GetApplePosition(Apple apple)
        {
            return Array.IndexOf(_apples, apple);
        }
    
        public void SetApplePosition(Apple apple, int position)
        {
            // if apple is already in position, do nothing
            if (object.ReferenceEquals(apple, _apples[position])) return;
            _apples[position] = apple;
        }
    
        public void AddApple(Apple apple, int position)
        {
            if (_apples[position] != null) throw new ArgumentException("Compartment already occupied", nameof(position));
            if (apple == null) throw new ArgumentNullException(nameof(apple));
            if (position < 0 || position > _apples.Length - 1) throw new IndexOutOfRangeException("Cannot add apple outside compartments");
            apple.MoveToBox(this, position);
        }
    }
