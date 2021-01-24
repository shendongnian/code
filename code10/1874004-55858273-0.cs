    public class RoomList<T>
    {
        public DailyList head;
        public DailyList Add()
        {
            var dailyList = new DailyList();
            if (head != null) head.next = dailyList;
            head = dailyList;
            return dailyList;
        }
        public class DailyList
        {
            public DailyList next;
            public DailyListElement head;
            public DailyListElement Add()
            {
                var dailyListElement = new DailyListElement();
                if (head != null) head.next = dailyListElement;
                head = dailyListElement;
                return dailyListElement;
            }
            public class DailyListElement
            {
                public T data;
                public DailyListElement next;
            }
        }
    }
