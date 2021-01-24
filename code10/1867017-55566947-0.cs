    public static class MonoBehaviourExtensions
    {
        public static void Invoke(this MonoBehaviour me, Action theDelegate, float time)
        {
            me.StartCoroutine(ExecuteAfterTime(theDelegate, time));
        }
     
        private static IEnumerator ExecuteAfterTime(Action theDelegate, float delay)
        {
            yield return new WaitForSeconds(delay);
            theDelegate?.Invoke();
        }
    }
    
