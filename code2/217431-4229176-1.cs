        public static void Test()
        {
            var states = new List<State>();
            _dueTime = DateTime.Now.AddSeconds(5);
            var initialState = new State() { Index = 0 };
            var initialTask = new Task(Go, initialState);
            Task priorTask = initialTask;
            for (int i = 1; i < 10; i++)
            {
                var state = new State { Index = i };
                priorTask = priorTask.ContinueWith(t => Go(state));
                states.Add(state);
                Thread.Sleep(100);
            }
            Task finalTask = priorTask;
            initialTask.Start();
            finalTask.Wait();
        }
