    public class UndoableAction
    {
        public UndoableActionType Type;
        public UnityEngine.Object target;
        public object from;
        public object to;
        public UndoableAction(UndoableActionType type, UnityEngine.Object target, object from, object to)
        {
            Type = type;
            Target = target;
            From = from;
            To = to;
        }
    }
    public enum UndoableActionType
    {
        Enable,
        SetActive,
        Position,
   
        // ... according to your needs
    }
    public class UndoRedoSystem : MonoBehaviour
    {
        private Stack<UndoableAction> availableUndos = new List<UndoableAction>();
        private Stack<UndoableAction> availableRedos = new List<UndoableAction>();
        public void TrackChangeAction(UndoableActionType type, UnityEngine.Object target, object from, object to)
        {
            // if you change something redo is cleared
            availableRedos.Clear();
            // Add this action do undoable actions
            availableUndos.Push(new UndoableAction(type, target, from, to));
        }
        public void Redo()
        {
            if(availableRedos.Count == 0) return;
            // get latest entry added to available Redos
            var redo = availableRedos.Pop();
            switch(redo.Type)
            {
                case UndoableActionType.Enable:
                    ((Component) redo.target).enabled = (bool)redo.To;
                    break;
                case UndoableActionType.SetActive:
                    ((GameObject) redo.target).SetActive((bool) redo.To);
                    break;
                case UndoableActionType.Position:
                    ((Transform) redo.target).position = (Vector3) redo.To;
                    break;
                
                // ... According to your needs 
            }
            // finally this is now a new undoable action
            availableUndos.Push(redo);
        }
        public void Undo()
        {
            if(availableUndos.Count == 0) return;
            // get latest entry added to available Undo
            var undo = availableUndos.Pop();
            switch(undo.Type)
            {
                case UndoableActionType.Enable:
                    ((Component) undo.target).enabled = (bool)undo.From;
                    break;
                case UndoableActionType.SetActive:
                    ((GameObject) undo.target).SetActive((bool) undo.From);
                    break;
                case UndoableActionType.Position:
                    ((Transform) undo.target).position = (Vector3) undo.From;
                    break;
                
                // ... According to your needs 
            }
            // finally this is now a new  redoable action
            availableRedos.Push(undo);
        }
    }
