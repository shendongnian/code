        public void RemoveAt(int index) {
            if ((uint)index >= (uint)_size) { 
                ThrowHelper.ThrowArgumentOutOfRangeException(); 
            }
            _size--; 
            if (index < _size) {
                Array.Copy(_items, index + 1, _items, index, _size - index);
            }
            _items[_size] = default(T); 
            _version++;
        } 
