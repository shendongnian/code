    public class ParticleTest : MonoBehaviour
    {
        public ParticleSystem part;
    
        void Start()
        {
            part = GetComponent<ParticleSystem>();
        }
    
        void OnParticleCollision(GameObject other)
        {
            if(other.tag == "Player")
               Debug.Log(other.tag);
        }
    }
