        public void AppendItem(T item)
        {
            if (list == null)
                list = new LinkGen<T>(item);
            else {
                LinkGen<T> temp = list;
                while (temp.Next != null) {
                    temp = temp.Next;
                }
                temp.Next = new LinkGen<T>(item);
            }
        }
        public void InsertInOrder(T item)
        {
            if (list == null || item.CompareTo(list.Data) < 0) {
                list = new LinkGen<T>(item) { Next = list };
            } else {
                LinkGen<T> temp = list;
                while (temp.Next != null && !(item.CompareTo(temp.Next.Data) < 0)) {
                    temp = temp.Next;
                }
                temp.Next = new LinkGen<T>(item) { Next = temp.Next };
            }
        }
