    public class ScriptA : MonoBehaviour
    {
        [Header("Base-Components")]
        public Renderer renderer;
    
        [Header("Base-Settings")]
        // start with this color
        public Color InitialColor = Color.white;
        // turn to this after being clicked
        public Color TargetColor = Color.white;
    
        [Header("Values")]
        public bool WasClicked;
    
        private void Awake()
        {
            SetUp();
        }
    
        private void SetUp()
        {
            if(!renderer) renderer = GetComponent<Renderer>();
            renderer.material.color = InitialColor;
    
            WasClicked = false;
        }
    
        private void OnMouseDown()
        {
            HandleClick();
        }
    
        // make this virtual so we can extend/overwrite it in child classes
        protected virtual void HandleClick()
        {
            WasClicked = true;
            renderer.material.color = TargetColor;
        }
    }
