    public class Room
    {
        private Room() {}
        public class Manager
        {
            public Room CreateRoom()
            {
                return new Room(); // And do other stuff, presumably
            }
        }
    }
