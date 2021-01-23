     public class WorkInfoEnumerator
        {
            List<WorkItem > wilist= null;
            int currentIndex = -1;
    
    
            public MyClassEnumerator(List<WorkItem > list)
            {
                wilist= list;
            }
           
            public WorkItem Current
            {
                get
                {
                    return wilist[currentIndex];
                }
            }
    
            public bool MoveNext()
            {
                ++currentIndex;
                if (currentIndex < wilist.Count)
                    return true;
                return false;
            }   
        }
    
    
        public class WorkInfo
        {
            List<WorkItem > mydata = new List<WorkItem >() {.... }; //init here, for example
            public WorkInfoEnumerator GetEnumerator()
            {
                return new WorkInfoEnumerator(mydata);
            }
        }
