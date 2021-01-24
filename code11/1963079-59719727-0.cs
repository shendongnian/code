        public Stack<Action> UndoStack { get; } = new Stack<Action>();
        public int Volatile { get; set; }
        public void Add(int i)
        {
            Volatile += i;
            UndoStack.Push(() => { Subtract(i); });
        }
        public void Subtract(int i)
        {
            Volatile -= i;
            UndoStack.Push(() => { Add(i); });
        }
        public void Undo()
        {
            var undoAction = UndoStack.Pop();
            undoAction();
        }
