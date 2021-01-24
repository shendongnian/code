    using UnityEngine;
    public class GetRaycast : MonoBehaviour
    {
        Camera camera;
    
        public Transform PlaneTransform;
        public Transform Player;
    
        // Start is called before the first frame update
        private void Start()
        {
            camera = Camera.main;
        }
    
        // Update is called once per frame
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                // you just need any 3 points inside of the plane and provide them
                // in clockwise order (so the normal points upwards)
                // for the raycast this actually wouldn't matter
                var plane = new Plane(PlaneTransform.position, PlaneTransform.position + PlaneTransform.forward, PlaneTransform.position + PlaneTransform.right);
    
                var ray = camera.ScreenPointToRay(Input.mousePosition);
                // enter will be the distance between the ray origin and the hit plane
                if (plane.Raycast(ray, out var enter))
                {
                    // GetPoint returns the position along the raycast in
                    // the given distance from the ray origin
                    Player.position = ray.GetPoint(enter) + Vector3.up * 0.1f;
                }
            }
        }
    }
