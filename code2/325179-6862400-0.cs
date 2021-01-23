        abstract class UndoableAction
        {
            public abstract void Do();
            public abstract void Undo();
        }
        Stack<UndoableAction> Actions;
