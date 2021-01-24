    public class MovementController : MonoBehaviour
    {
        void OnMouseDrag()
        {
            float planeY = 0;
            Transform draggingObject = transform;
     
            Plane plane = new Plane(Vector3.up, Vector3.up * planeY); // ground plane
     
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
     
            float distance; // the distance from the ray origin to the ray intersection of the plane
            if(plane.Raycast(ray, out distance))
            {
                draggingObject.position = ray.GetPoint(distance); // distance along the ray
            }
        }
    }
