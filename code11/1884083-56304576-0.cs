    using UnityEngine;
    
    public class DestroyAfterRandomDelay : MonoBehaviour
    {
    
        [Tooltip("Minimum delay value")]
        public float MinimumDelay = 0f;
        
        [Tooltip("Maximum delay value")]
        public float MaximumDelay = 4f;
        
        // keeps track of elapsed time
        private float _elapsedTime= 0;
    
        // Keeps track of random delay 
        private float _randomDelay;
        // Start is called before the first frame update
        void Start()
        {
            // Sets random delay on start
            _randomDelay = Random.Range(MinimumDelay, MaximumDelay);
            
            Debug.LogFormat("{0} will be destroyed in {1} seconds!", this.name, _randomDelay);
        }
    
        // Update is called once per frame
        void Update()
        {
            
            // Increment time passed
            _elapsedTime += Time.deltaTime;
            
            // Proceed only if the elapsed time is superior to the delay
            if(_elapsedTime < _randomDelay) return;
            
            Debug.LogFormat("Destroying {0} after {1} seconds! See Ya :)", this.name, _elapsedTime);
            
            // Destroy this GameObject!
            Destroy(this.gameObject);
            
        }
    }
  
