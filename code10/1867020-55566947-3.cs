    public static class MonoBehaviourExtensions
    {
        public static void Invoke(this MonoBehaviour me, Action theDelegate, float time)
        { ... }
     
        private static IEnumerator ExecuteAfterTime(Action theDelegate, float delay)
        { ...  }
        public static void InvokeRepeated(this MonoBehaviour me, Action theDelegate, float timeInterval)
        {
            StartCoroutine(ExecuteInIntervals(theDelegate, interval));
        }
        private static IEnumerator ExecuteInIntervals(Action theDelegate, float interval)
        {
            while(true)
            {
                yield return new WaitForSeconds(interval);
                theDelegate?.Invoke();
            }
        }
    }
