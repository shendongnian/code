    interface IUndoableAction
    {
        void Do();
        void Undo();
    }
    Stack<IUndoableAction> Actions;
