    public class Machine
    {
        public enum Action
        {
            OpenDoor,
            CloseDoor,
            // other values
        }
        public void DoAction(Action ActionToDo)
        {
            switch(ActionToDo)
            {
                case OpenDoor:
                    // open the door
                    break;
                case CloseDoor:
                    // close the door
                    break;
                default:
                    break;
            }
        }
    }
