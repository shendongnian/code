using UnityEngine;
using System.Collections;
 
public class BoundingBox: MonoBehaviour
{
    void OnDrawGizmos()
    {
        Renderer rend = GetComponent<Renderer>();
        if (rend)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(rend.bounds.center, rend.bounds.size);
        }
    }
//If your object is not within the bounding boundaries, then you can set your mesh up manually like this;
     void Start()
     {
       var meshFilter = GetComponent<MeshFilter>();
       meshFilter.mesh.bounds = new Bounds(transform.position, new Vector3(10, 5, 1));
     } 
}
