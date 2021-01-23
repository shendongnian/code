            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(2);
            queue.Enqueue(4);
            int number =(from c in queue
                         group c by c into g
                         orderby g.Count() descending
                         select g.Key).FirstOrDefault();
