    using UnityEngine;
    public class NewBehaviourScript : MonoBehaviour
    {
    	[SerializeField] MeshFilter meshFilter = null;
    	Vector3[] vertices = { vertices goes here };
    	int[] triangles = { indices goes here };
        void Start ()
        {
    		Mesh mesh = new Mesh();
    		meshFilter.mesh = mesh;
    
    		Vector2[] uvs = new Vector2[ vertices.Length ];
    		int numTriangles = triangles.Length / 3;
    		for( int t=0 ; t<numTriangles ; t++ )
    		{
    			int ia = triangles[ t*3 ];
    			int ib = triangles[ t*3+1 ];
    			int ic = triangles[ t*3+2 ];
    
    			Vector3 va = vertices[ ia ];
    			Vector3 vb = vertices[ ib ];
    			Vector3 vc = vertices[ ic ];
    
    			Vector3 normal = Vector3.Cross( vb-va , vc-va ).normalized;
    
    			if( Vector3.Dot( normal , Vector3.forward )>0.7071f )
    			{
    				// front projection
    				uvs[ ia ] = new Vector2{ x=-va.x , y=va.y };
    				uvs[ ib ] = new Vector2{ x=-vb.x , y=vb.y };
    				uvs[ ic ] = new Vector2{ x=-vc.x , y=vc.y };
    			}
    			else if( Vector3.Dot( -normal , Vector3.forward )>0.7071f  )
    			{
    				// back projection
    				uvs[ ia ] = new Vector2{ x=va.x , y=va.y };
    				uvs[ ib ] = new Vector2{ x=vb.x , y=vb.y };
    				uvs[ ic ] = new Vector2{ x=vc.x , y=vc.y };
    			}
    			else if( Vector3.Dot( normal , Vector3.right )>0.7071f )
    			{
    				// right side projection
    				uvs[ ia ] = new Vector2{ x=-va.z , y=va.y };
    				uvs[ ib ] = new Vector2{ x=-vb.z , y=vb.y };
    				uvs[ ic ] = new Vector2{ x=-vc.z , y=vc.y };
    			}
    			else if( Vector3.Dot( -normal , Vector3.right )>0.7071f )
    			{
    				// left side projection
    				uvs[ ia ] = new Vector2{ x=va.z , y=va.y };
    				uvs[ ib ] = new Vector2{ x=vb.z , y=vb.y };
    				uvs[ ic ] = new Vector2{ x=vc.z , y=vc.y };
    			}
    			else if( Vector3.Dot( normal , Vector3.up )>0.7071f )
    			{
    				// top projection
    				uvs[ ia ] = new Vector2{ x=-va.x , y=va.z };
    				uvs[ ib ] = new Vector2{ x=-vb.x , y=vb.z };
    				uvs[ ic ] = new Vector2{ x=-vc.x , y=vc.z };
    			}
    			else
    			{
    				// bottom projection
    				uvs[ ia ] = new Vector2{ x=va.x , y=va.z };
    				uvs[ ib ] = new Vector2{ x=vb.x , y=vb.z };
    				uvs[ ic ] = new Vector2{ x=vc.x , y=vc.z };
    			}
    		}
    
    		mesh.vertices = vertices;
    		mesh.triangles = triangles;
    		mesh.uv = uvs;
    
    		mesh.RecalculateNormals ();
        }
    }
