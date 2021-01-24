    public class MovementController : MonoBehaviour
    {
        private const float planeY = 0f;
    
        Plane plane = new Plane(Vector3.up, Vector3.up * planeY); // ground plane
 
        void OnMouseDrag()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
 
            float distance; // the distance from the ray origin to the ray intersection of the plane
            if(plane.Raycast(ray, out distance))
            {
                transform.position = ray.GetPoint(distance); // distance along the ray
            }
        }
    }
