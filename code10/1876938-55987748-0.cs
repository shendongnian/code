    public class Interpreter<T>
    {
        public Stack<T> TypeStack { get; set; }
        public Interpreter()
        {
            if (this.TypeStack == null)
            {
                this.TypeStack = new Stack<T>();
            }
        }
        public void Push(T value)
        {
            this.TypeStack.Push(value);
        }
        public void Pop()
        {
            this.TypeStack.Pop();
        }
    }
