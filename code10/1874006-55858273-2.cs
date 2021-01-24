    public class RoomList<T>
    {
        public DailyList head;
        public DailyList Add()
        {
            var newItem = new DailyList();
            if (head != null) head.next = newItem;
            head = newItem;
            return newItem;
        }
        public class DailyList
        {
            public DailyList next;
            public DailyListElement head;
            public DailyListElement Add()
            {
                var newItem = new DailyListElement();
                if (head != null) head.next = newItem;
                head = newItem;
                return newItem;
            }
            public class DailyListElement
            {
                public T data;
                public DailyListElement next;
            }
        }
    }
