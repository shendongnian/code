    using UnityEngine.Audio;
    public class Octavas : MonoBehaviour
    {
    public GameObject PianoAudioManager;
  
    public void OctaveDown()
    {
        AudioMixer audioMixer = Resources.Load<AudioMixer>("Scales/Sounds");
        audioMixer.SetFloat("PianoPitch", 0.5f);
    }
    }
