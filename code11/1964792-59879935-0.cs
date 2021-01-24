    [RequireComponent(typeof(MeshCollider))]
    public class MeshCompositeCollider : MonoBehaviour
    {
        void Start()
        {
            var meshColliders = GetComponentsInChildren<MeshCollider>();
            var combine = new CombineInstance[meshColliders.Length];
    
            for (int i = 0; i < meshColliders.Length; i++)
            {
                combine[i].mesh = meshColliders[i].sharedMesh;
                combine[i].transform = meshColliders[i].transform.localToWorldMatrix;
                meshColliders[i].enabled = false;
            }
    
            var compositeMesh = new Mesh();
            compositeMesh.CombineMeshes(combine);
            //WeldVertices(compositeMesh);
            GetComponent<MeshCollider>().sharedMesh = compositeMesh;
            GetComponent<MeshCollider>().enabled = true;
        }
    }
