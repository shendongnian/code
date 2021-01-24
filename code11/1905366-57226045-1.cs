    using UnityEngine;
    
    public class Building : MonoBehaviour {
    
    public GameObject block;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            Instantiate(block, pos, Quaternion.identity);
        }
    }
    }
