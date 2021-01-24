    public class BombDemo : MonoBehaviour
    {
        private AudioSource _soundEffect;
    
        private void Awake()
        {
            _soundEffect = GetComponent<AudioSource>();
        }
    
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _soundEffect.Play();
            }
        }
    }
