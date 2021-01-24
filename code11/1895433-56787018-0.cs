    using UnityEngine;
    
    public class StickToTerrain : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    
                if (Physics.Raycast(ray, out RaycastHit terrainHit))
                {
                    transform.up = terrainHit.normal;
                }
            }
        }
    }
