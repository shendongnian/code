    public class MouseEffect : MonoBehaviour
    {
        public float zOffset = -2f;
        public Vector2 tolerance = Vector2.one;
        Quaternion originalRotation;
    
        private void OnMouseEnter()
        {
            // Storing the original rotation so we can reset to it when we aren't hovering anymore
            originalRotation= transform.rotation;
        }
    
        private void OnMouseOver()
        {
            Vector3 localOffset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            // Multiplying by a adjustable tolerance, this is just a matter of preference if you want more rotation on the xAxis/yAxis or not.
            localOffset.x *= tolerance.x;
            localOffset.y *= tolerance.y;
            Vector3 worldOffset = transform.position + localOffset;
            // Setting a zOffset it will be really weird to adjust the rotation to look at something on the same Z as it.
            worldOffset.z = transform.position.z + zOffset;
            // Transform.LookAt for simplicity sake.
            transform.LookAt(worldOffset);
        }
    
        private void OnMouseExit()
        {
            // This can cause a bit of a twitching effect if you are right on the edge of the collider.
            transform.rotation = originalRotation;
        }
    }
