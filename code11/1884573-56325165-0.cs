    public class HintScript : MonoBehaviour 
    {
        // by adding SerializeField you can already set those references
        // directly in the Unity Editor. This is better than getting them at runtime.
        [SerializeField] private LineRenderer line;
        [SerializeField] private AdMobManager adMobManager;
        // you can still change the required clicks in the inspector
        // Note: afterwards changing it here will have no effect!
        [SerializeField] private int requiredClicks = 3;    
        // counter for your clicks
        private int counter;
    
        // Use this for initialization
        void Start () 
        {
            // you should do this only once
            line = GetComponent<LineRenderer>();
    
            // you should also this only do once
            adMobManager = FindObjectOfType<AdMobManager>();
    
            // If instead you would drag those references directly into the now
            // serialized fields you wouldn't have to get them on runtime at all.
        }
    
        // Update is called once per frame
        void Update () 
        { 
            line.positionCount = transform.childCount;
            var positions = new Vector3[transform.childCount];
            for (var i = 0; i < transform.childCount; i++)
            {
                position[i] = transform.GetChild(i).position;
            }
    
            // it is more efficient to call this only once
            // see https://docs.unity3d.com/ScriptReference/LineRenderer.SetPositions.html
            line.SetPositions(positions);
        }
    
        // This is called from onClick of the Button
        public void Hint() 
        { 
            counter++;
    
            if(counter < requiredClicks) return;
    
            adMobManager.Hint = true; 
            adMobManager.showInterstitial(); 
            // reset the counter
            counter = 0;
        }
    }
