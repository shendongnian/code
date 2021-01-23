        void PerformAction(IUndoableActionaction)
        {
            Actions.Push(action);
            action.Do();
        }
        void Undo()
        {
            var action = Actions.Pop();
            action.Undo();
        }
