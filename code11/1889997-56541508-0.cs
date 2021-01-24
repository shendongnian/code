    public class DoorFall : MonoBehaviour {
    
        private AudioSource doorFallAudioSource;
    
        // Use this for initializatoin
        void Start() {
    
            doorFallAudioSource = GetComponent<AudioSource>();
    
        }
    
        // Update is called once per frame
        void Update() {
    
        }
    
        void OnCollisionEnter (Collision collision) {
            if (collision.gameObject.tag == "player")
            {
    
                doorFallAudioSource.play();
    
                Destroy(collision.gameObject);
            }
        }
    }
