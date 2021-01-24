    public class Path
    {
        public Vector2[] Points { get; private set; }
        public int Capacity => Points.Length;
    
        int head;
    
        public Path(int capacity)
        {
            head = 0;
            Points = new Vector2[capacity];
        }
    
        public void Resize()
        {
            Vector2[] temp = new Vector2[Capacity * 2];
    
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = i < Capacity ? Head(i + 1) : Tail();
            }
    
            head = Capacity - 1;
    
            Points = temp;
        }
    
        public void Add(Vector2 pos)
        {
            int prev = Mod(head, Capacity);
    
            Next();
    
            int next = Mod(head, Capacity);
    
            Points[next].pos = pos;
        }
    
        public Vector2 Head()
        {
            return Points[head];
        }
    
        public Vector2 Head(int index)
        {
            return Points[Mod(head + index, Capacity)];
        }
    
        public Vector2 Tail()
        {
            return Points[Mod(head + 1, Capacity)];
        }
    
        public Vector2 Tail(int index)
        {
            return Points[Mod(head + 1 + index, Capacity)];
        }
    
        void Next()
        {
            head++;
            head %= Capacity;
        }
    
        int Mod(int x, int m)
        {
            return (x % m + m) % m;
        }
    }
