    public class SpashImageMover : MonoBehaviour
    {
        public Vector3 startPosition;
        public Vector3 endPosition;
        public float3 lerpTime;
    
        private float t = 0; // in case code in Start is removed
  
        void Start()
        {
            // remove these two lines if you don't want the objects synchronized
            t = Mathf.Repeat(Time.time/lerpTime, 1f);
            transform.position = Vector3.Lerp(startPosition, endPosition, t);
        }
    
        void Update()
        {
            t = Mathf.Repeat(t + Time.deltaTime / lerpTime, 1f);
    
            transform.position = Vector3.Lerp(startPosition, endPosition, t);
        }
    }
    public class IntegratedScrpt : MonoBehaviour
    {
        public List<GameObject> splashImagesGOList;
    
        public float InvokeRate = 10f;
    
        private int selection;
    
        // Loop mode variables
        private Vector3 startPosition;
        private Vector3 endPosition;
    
        //for Vector Lerp
        private float lerpTime = 9f;
        // end condition for PickPoints
        private bool invokingPickPoints;
        private float pickPointsTimeRemaining = 27f;
    
    
        void Start()
        {
            startPosition = splashImagesGOList[1].transform.position;
            Debug.LogError("selection VALUE AT" + selection);
    
            endPosition = Vector3.back * distance;
            InvokeRepeating("PickPoints", 1.0f, InvokeRate);
            invokingPickPoints = true;
        }
    
        void Update()
        {
            if (invokingPickPoints) 
            {
                pickPointsTimeRemaining -= Time.deltaTime;
                if (pickPointsTimeRemaining <= 0 ) 
                {
                    CancelInvoke("PickPoints");
                    invokingPickPoints = false;
                }
            }
        }
        // code for instantiating the gameobjects
        void PickPoints()  
        {
            foreach (GameObject cube01 in splashImagesGOList)
            {
                int selection = UnityEngine.Random.Range(0, splashImagesGOList.Count);
                // Instantiate(splashImagesGOList[selection], cube01.transform.position, cube01.transform.rotation);
                GameObject newGO = Instantiate(splashImagesGOList[selection], startPosition, cube01.transform.rotation);
                
                SpashImageMover mover = newGO.GetComponent<SpashImageMover>();
                mover.startPosition = startPosition;
                mover.endPosition = endPosition;
                mover.lerpTime = lerpTime;
            }
        }
    }
