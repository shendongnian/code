    internal public class PriorityQueue<TValue> 
    {
        private Dictionary<int, List<TValue>> mDict;
     
        // only Add, TryGetValue shown...
        public void Add(int pPriority, TValue pInput) 
        {
            List<TValue> tTmp;
            if (mDict.TryGetValue(pPriority, tTmp)) 
            {
                tTmp.Add(pInput);
            } 
            else 
            {
                mDict.Add(pPriority, new List<TValue>{ pInput });
            }
        }
    
        public bool TryGetValue(int pPriority, out List<TValue>) 
        {
            // obvious...
        }
    }
