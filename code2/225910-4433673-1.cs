        private static int _counter = -1;
        public static void DoWork(Object stateInfo)
        {
            int index;
            while (index = Interlocked.Increment(ref _counter) < MyList.Count)
            {
                string id = MyList[index];
                var record = _repository.GetRecord(id);
                lock (LockObject)
                {                    
                    _repository.Add(record);
                }
                if (index % 100 == 0)
                    Console.WriteLine(DateTime.Now + " - Imported " + (index + 1) + " Records..");
            }
        }
