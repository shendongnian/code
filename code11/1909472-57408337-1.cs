    public class ColorFade : MonoBehaviour
    {
        [Header("Components")]
        // reference this in the Inspector if possible
        [SerializeField] private Renderer renderer;
        [Header("Settings")]
        [SerializeField] private Color startColor;
        [SerializeField] private Color EndColor;
    
        // fade duration for a complete 0-100 fade
        // fading will be shorter if only fading parts
        [SerializeField] private float fadeDuration = 1f;
    
        [Header("Debug")]
    
        [SerializeField][Range(0f, 1f)] private float currentFade;
    
        private void Awake()
        {
            if(!renderer) renderer = GetComponent<Renderer>();
            startColor = renderer.material.color;
        }
    
        public void FadeIn()
        { 
            // avoid concurrent routines
            StopAllCoroutines();
    
            StartCoroutine(FadeTowards(1));
        }
    
        public void FadeOut()
        {
            // avoid concurrent routines
            StopAllCoroutines();
    
            StartCoroutine(FadeTowards(0));
        }
    
        private IEnumerator FadeTowards(float targetFade)
        {
            while(!Mathf.Approximately(currentFade, targetFade))
            {
                // increase or decrease the currentFade according to the fade speed
                if(currentFade < targetFade)
                    currentFade += Time.deltaTime / fadeDuration;
                else
                    currentFade -= Time.deltaTime / fadeDuration;
    
                // if you like you could even add some ease-in and ease-out here
                //var lerpFactor = Mathf.SmoothStep(0, 1, currentFade);
    
                renderer.material.color = Color.Lerp(startColor, EndColor, currentFade /*or lerpFactor for eased fading*/);
                // let this frame be rendered and continue from this point
                // in the next frame
                yield return null;
            }
        }
    }
 
