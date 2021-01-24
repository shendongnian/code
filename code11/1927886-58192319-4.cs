    public class ColorChanger : MonoBehaviour {
        //Avoid Find and GetComponent methods in performance-critical contexts like Update and FixedUpdate
        //Store the value once in the beginning. This is called 'caching'
        public SpriteRenderer _renderer;
        //Don't hard-code stuff like this
        public Color[] _colors;
        public float _colorChangeInterval = 0.5f;
        //Convenience property to access _renderer.color
        public Color Color {
            get => _renderer.color;
            set => _renderer.color = value;
        }
        private void Start() {
            //Attempts to find the SpriteRenderer in the object if it wasn't set in the inspector
            if (!_renderer)
                _renderer = GetComponent<SpriteRenderer>();
        }
        //This piece of code does a specific thing, so it's best to put it in a method
        public void ChangeColor() {
            if (_colors.Length < 1)
                Debug.LogError($"You forgot to set {nameof(_colors)} in the Inspector. Shame! Shame!");
            Color = _colors[Random.Range(0, _colors.Length - 1)];
        }
    }
