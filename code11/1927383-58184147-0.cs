    public class PickUpObject : MonoBehaviour {
    
    	public float delayTime = 2.0f;
        public float currentTime = 0.0f;
    
        private void Update()
        {
            currentTime += Time.deltaTime;
        }
        void OnCollisionEnter (Collision Col)
        {
            if (Col.gameObject.name== "Player" && currentTime > delayTime)
            {
                delayTime += currentTime;
    
                Destroy(gameObject);
                
                delayTime -= currentTime;
                currentTime = 0.0f;
    
            }
        }
    }
