    sealed class UndoRedo<T>
    {
        T current = default(T);
        IImmutableList<T> undo = ImList<T>.Empty
        IImmutableList<T> redo = ImList<T>.Empty;
        public T Current
        {
            get { return current; }
            set
            {
                undo = undo.Append(current);
                redo = ImList<T>.Empty;
                current = value;
            }
        }
        public void Undo()
        {
            var newCurrent = undo.LastItem;
            undo = undo.RemoveLast();
            redo = redo.Append(current);
            current = newCurrent;
        }
        public void Redo()
        {
            var newCurrent = redo.LastItem;
            undo = undo.Append(current);
            redo = redo.RemoveLast();
            current = newCurrent;
        }
    }
     
