    public class Example : MonoBehaviour
    {
        public Renderer renderer;
        public Collider collider;
    
        private void Awake()
        {
            renderer = GetComponent<Renderer>();
            Destroy(renderer);
        }
    
        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Space)) return;
    
            CheckReference(renderer); // MissingComponentException
            CheckReference(collider); // UnassignedReferenceException
    
            Sprite sprite = null;
    
            CheckReference(sprite);   // NullReferenceException
    
            sprite = Sprite.Create(new Texture2D(1, 1), new Rect(0, 0, 1, 1), Vector2.zero);
            DestroyImmediate(sprite);
            CheckReference(sprite);   // MissingReferenceException
        }
    
        public void CheckReference(Object reference)
        {
            try
            {
                var blarf = reference.name;
            }
            catch (MissingReferenceException) // General Object like GameObject/Sprite etc
            {
                Debug.LogError("The provided reference is missing!");
            }
            catch (MissingComponentException) // Specific for objects of type Component
            {
                Debug.LogError("The provided reference is missing!");
            }
            catch (UnassignedReferenceException) // Specific for unassigned fields
            {
                Debug.LogWarning("The provided reference is null!");
            }
            catch (NullReferenceException) // Any other null reference like for local variables
            {
                Debug.LogWarning("The provided reference is null!");
            }
        }
    }
