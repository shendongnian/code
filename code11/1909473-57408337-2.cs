    public class RaycastSelection : MonoBehaviour
    {
        [Header("Components")]
    
        // reference this via the Inspector already if possible
        [SerializeField] private Camera camera;
    
        [Header("Debug")]
    
        [SerializeField] private ColorFade lastFaderHit;
    
        private void Awake()
        {
            if (!camera) camera = Camera.main;
        }
    
        private void Update()
        {
            RaycastHit hit;
            if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                // if hitting same object do nothing
                if (lastFaderHit && hit.transform == lastFaderHit.transform) return;
    
                // if looking on different object start fade out previous if exists
                lastFaderHit?.FadeOut();
    
                // start fade in current
                var current = hit.transform.GetComponent<ColorFade>();
                current?.FadeIn();
    
                // update previous hit
                lastFaderHit = current;
            }
            else
            {
                // if looking at nothing start fadeout previous hit if exists
                lastFaderHit?.FadeOut();
    
                // reset previous hit
                lastFaderHit = null;
            }
        }
    }
