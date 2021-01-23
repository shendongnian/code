        public class ThreadSafeClass
        {
            private List<int> commandList = new List<int>();
            public void AddCommand(int newCommand)
            {
              lock(commandList){
                commandList.Add(newCommand);
              }
            }
            public List<int> Split()
            {
              lock(commandList){
                List<int> oldList = commandList;
                commandList = new List<int>();
              }
                return oldList;
            }
        }
