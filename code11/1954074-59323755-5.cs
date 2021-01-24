    public class Example : MonoBehaviour
    {
        public Transform PointA;
        public Transform PointB;
        void Update()
        {
            // Set the position to loop between PointA and PointB
            transform.position = Vector3.Lerp(PointA, PointB, Mathf.PingPong(Time.time / speed, 1));
        }
    }
---
