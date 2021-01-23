        public class ThreadSafeClass
        {
            private object sync = new object();
            private List<int> commandList = new List<int>();
            public void AddCommand(int newCommand)
            {
              lock(sync){
                commandList.Add(newCommand);
              }
            }
            public List<int> Split()
            {
              lock(sync){
                List<int> oldList = commandList;
                commandList = new List<int>();
              }
                return oldList;
            }
        }
