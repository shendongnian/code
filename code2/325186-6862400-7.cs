        void PerformAction(IUndoableActionaction)
        {
            Actions.Push(action);
            action.Do();
        }
        void Undo()
        {
            if(Actions.Count > 0)
            {
                var action = Actions.Pop();
                action.Undo();
            }
        }
