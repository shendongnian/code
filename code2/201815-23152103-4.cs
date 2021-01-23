    public static class MsmqEx
    {
        public static int Count(this MessageQueue queue)
        {
            int count = 0;
            var enumerator = queue.GetMessageEnumerator2();
            while (enumerator.MoveNext())
                count++;
            
            return count;
        }
    }
