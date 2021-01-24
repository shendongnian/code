    public class CountdownTimer : MonoBehaviour
    {
        float currentTime = 0f;
        float startingTime = 10f;
        public static event Action RaiseReady;
    
        // Start is called before the first frame update
        void Start()
        {
            currentTime = startingTime;
            StartCoroutine(UpdateCoroutine());
        }
    
        // Update is called once per frame
        IEnumerator UpdateCoroutine()
        {        
            currentTime -= 1 * Time.deltaTime; //does it each frame
            int n = Convert.ToInt32(currentTime);
            if (n == 8)
            {
                RaiseReady?.Invoke();
                RaiseReady = null; // clean the event
                yield break; // Kills the coroutine
            }
            yield return null;
        }
    }
