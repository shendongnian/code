    class ResizableArray<T>
    {
        T[] m_array;
        int m_count;
    
        public ResizableArray(int? initialCapacity = null)
        {
            m_array = new T[initialCapacity ?? 4]; // or whatever
        }
    
        internal T[] InternalArray { get { return m_array; } }
    
        public int Count { get { return m_count; } }
    
        public void Add(T element)
        {
            if (m_count == m_array.Length)
            {
                Array.Resize(ref m_array, m_array.Length * 2);
            }
    
            m_array[m_count++] = element;
        }
    }
