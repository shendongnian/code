    public class AudioManager : MonoBehaviour
    {
        static AudioManager instance;
        public static AudioManager Instance => instance ?? (instance = new GameObject("AudioManager", typeof(AudioManager)).GetComponent<AudioManager>());
    
        public void PlaySound(SoundType soundType)
        {
            Debug.Log("Play Sound: " + soundType);
        }
    }
