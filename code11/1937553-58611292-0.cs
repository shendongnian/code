    public class Highlights : MonoBehaviour {
        public Material highlightMaterial;
        Material originalMaterial;
        GameObject lastHighlightedObject;
        bool highlightSet; // new
        void Start() // new
        {
            highlightSet = false;
        }
        void HighlightObject(GameObject gameObject)
        {
            if (lastHighlightedObject != gameObject)
            {
                ClearHighlighted();
                originalMaterial = gameObject.GetComponent<MeshRenderer>().sharedMaterial;
                gameObject.GetComponent<MeshRenderer>().sharedMaterial = highlightMaterial;
                lastHighlightedObject = gameObject;
            } 
        }
        void ClearHighlighted()
        {
            if (lastHighlightedObject != null)
            {
                lastHighlightedObject.GetComponent<MeshRenderer>().sharedMaterial = originalMaterial;
                lastHighlightedObject = null;
            }
        }
        // Navigates to highlight every object on camera. 
        void HighlightObjectInCenterOfCam()
        {
            float rayDistance = 1000.0f;
            // The ray from the center of the viewport.
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit rayHit;
            // Check if we hit something.
            if (Physics.Raycast(ray, out rayHit, rayDistance))
            {
                // Get the object that was hit.
                GameObject hitObject = rayHit.collider.gameObject;
                HighlightObject(hitObject);
            } else
            {
                ClearHighlighted();
            }
        }
        void Update()
        {
            // unset highlight if object is null (undefined or destroyed)
            if (lastHighlightedObject == null)
            {
                highlightSet = false;
            }
          
            if (!highlightSet)
            {
                HighlightObjectInCenterOfCam();
            }
        }
        public void SetHighlight() 
        { 
            // only set highlight if there is a highlighted object
            if (lastHighlightedObject != null) 
                highlightSet = true; 
        }
 
        public void UnsetHighlight() { highlightSet = false; }
    }
