    void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<AudioCollection>().PlayRandom();
    }
    public class AudioCollection : MonoBehaviour
    {
        [SerializeField] AudioClip[] clips;
        [SerializeField] AudioSource source;
    
        void PlayRandom()
        {
            source.clip = clips[Random.Range(0, clips.Length)];
            source.Play();
        }
    }
