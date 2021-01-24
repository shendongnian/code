        public static void insertLast(LinkedList<Person> list, Person data)
        {
            if (list.Count == 0)
            {
                list.AddFirst(data);
            }
            else
            {
                list.AddAfter(list.Last, data);
            }
        }
