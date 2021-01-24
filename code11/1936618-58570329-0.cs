    public class Waiter : MonoBehaviour
    {
        static Waiter instance = null;
        static Waiter Instance
        {
            get
            {
                if (instance == null)
                    instance = new GameObject("Waiter").AddComponent<Waiter>();
                return instance;
            }
        }
        private void Awake()
        {
            instance = this;
        }
        private void OnDestroy()
        {
            if (instance == this)
                instance = null;
        }
    
        IEnumerator WaitRoutine(float duration, System.Action callback)
        {
            yield return new WaitForSeconds(duration);
            callback?.Invoke();
        }
    
        public static void Wait(float seconds, System.Action callback)
        {
            Instance.StartCoroutine(Instance.WaitRoutine(seconds, callback));
        }
    }
