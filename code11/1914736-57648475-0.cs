        public Task clock()
        {
            while (true)
            {
                Console.WriteLine(DateTime.Now.ToString());
                Task.Run(() => Task.Delay(1000));
                Console.Clear();
            }
        }
