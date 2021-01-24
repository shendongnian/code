    public class MovementController : MonoBehaviour
    {
        Vector3 startPos;
        Vector3 dist;
        void OnMouseDown()
        {
            startPos = Camera.main.WorldToScreenPoint(transform.position);
            dist = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, startPos.y, Input.mousePosition.y));
        }
        void OnMouseDrag()
        {
            Vector3 lastPos = new Vector3(Input.mousePosition.x, startPos.y, Input.mousePosition.y);
            transform.position = Camera.main.ScreenToWorldPoint(lastPos) + dist;
        }
    }
