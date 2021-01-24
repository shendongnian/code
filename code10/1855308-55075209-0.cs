    public class FadeScript : MonoBehaviour
    {
        public Material fadeMaterial;
        public float fadeTime = 2f;
        private float fadeTimer = 0f;
    
        // Start is called before the first frame update
        void Start()
        {
            fadeTimer = 0f;
        }
    
        // Update is called once per frame
        void Update()
        {
            if (fadeTimer < fadeTime) fadeTimer += Time.deltaTime;
    
            fadeMaterial.color = new Color(
                fadeMaterial.color.r,
                fadeMaterial.color.g,
                fadeMaterial.color.b,
                fadeTimer / fadeTime);
        }
    }
