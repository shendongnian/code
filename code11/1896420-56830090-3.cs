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
                var plane = new Plane(PlaneTransform.position, PlaneTransform.position + PlaneTransform.right, PlaneTransform.position + PlaneTransform.forward);
    
                var ray = camera.ScreenPointToRay(Input.mousePosition);
                if (plane.Raycast(ray, out var enter))
                {
                    Player.position = ray.GetPoint(enter) + Vector3.up * 0.1f;
                }
            }
        }
    }
