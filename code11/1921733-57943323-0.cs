    using UnityEngine.UI;
    public class SettingsMenu : MonoBehaviour
    {
        [SerializeField]
        private Slider _volumeSlider;
    
        public void SetVolume()
        {
            float volume = _volumeSlider.value;
            audioMixer.SetFloat("Volume", volume);
        }
    }
