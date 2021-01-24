    public class MusicToggleButton : MonoBehaviour {
        public Image offOnImage;
       public bool changeValue;
        public Color TargetColor;
       public Color originalColor;
    	// Use this for initialization
    	void Start () {
            changeValue = !(PlayerPrefsManager.GetMusicOnOff() == 1);
            if (PlayerPrefsManager.GetMusicOnOff() == 1)
            {
                Debug.Log("stop Music");
                offOnImage.color = TargetColor;
            }
            else {
    
                Debug.Log("Playing Music");
                offOnImage.color = originalColor;
            }
           
    
        }
    
        public void musicButtonClick()
        {
            changeValue = !changeValue;
            if (changeValue)
            {
                //Debug.Log("changing to target color");
                //offOnImage.CrossFadeColor(TargetColor, 0.5f, false, false);
                offOnImage.color = originalColor;
                Debug.Log("Playing");
            }
            else
            {
                //Debug.Log("changing to original color");
                //offOnImage.CrossFadeColor(Color.white, 0.5f, false, false);
                Debug.Log("pause");
                offOnImage.color = TargetColor;
            }
        }
