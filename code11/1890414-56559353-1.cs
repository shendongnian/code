csharp
    public class CountingPassthrough : MonoBehaviour
    {
        public CountdownTimer countdownTimer;
    }
put this component on the scene's "Timer" `GameObject`
csharp
    public class CountdownTimer : MonoBehaviour
    {
        public float startingTime = 10f;
        public UnityEvent timedOut = new UnityEvent();
    
        private void OnValidate()
        {
            if(FindObjectOfType<CountingPassthrough>().gameObject.scene == gameObject.scene && FindObjectOfType<CountingPassthrough>() != new UnityEngine.SceneManagement.Scene())
                FindObjectOfType<CountingPassthrough>().countdownTimer = this;
        }
    
        private void Start()
        {
            StartCoroutine(TimerCoroutine());
        }
    
        // Coroutine is called once per frame
        private IEnumerator TimerCoroutine()
        {
            float currentTime = 0f;
            while (currentTime != 0)
            {
                currentTime = Mathf.Max(0, currentTime - Time.deltaTime);
                yield return null;//wait for next frame
            }
            timedOut.Invoke();
        }
    }
Put this component on the `GameObject` you want to use the timer
csharp
    public class user : MonoBehaviour
    {
        [SerializeField, HideInInspector]
        private CountingPassthrough timerObject;
    
        private void OnValidate()
        {
            if(FindObjectOfType<CountingPassthrough>().gameObject.scene == gameObject.scene && FindObjectOfType<CountingPassthrough>() != new UnityEngine.SceneManagement.Scene())
                timerObject = FindObjectOfType<CountingPassthrough>();
        }
    
        private void OnEnable()
        {
            timerObject.countdownTimer.timedOut.AddListener(DoSomething);
        }
    
        private void OnDisable()
        {
            timerObject.countdownTimer.timedOut.RemoveListener(DoSomething);
        }
    
        private void DoSomething()
        {
            //do stuff here...
        }
    }
This workflow is friendly to prefabs too, because you can wrap the `find()` in `onvalidate()` with `if(FindObjectOfType<CountingPassthrough>().gameObject.scene == gameObject.scene)` to prevent grabbing the wrong asset from other loaded scenes.  And again, if you need this to carry data across scenes then have `CountingPassthrough` inherit from `ScriptableObject` instead of `MonoBehaviour`, create the new `ScriptableObject` to your project folder somewhere, and ignore that extra if check to constrain scene matching.  Then just make sure you use a function to find it that includes assets if you use the cross-scene `ScriptableObject` approach.  
**EDIT:Forgot nested prefabs edgecase in unity 2018+ versions.  You need to add this to account for it: `&& FindObjectOfType<CountingPassthrough>() != new UnityEngine.SceneManagement.Scene()` I've updated the code snippet above.  Sorry about that.**
