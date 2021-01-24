    public class MaterialChanger : MonoBehaviour {
    public Material[] Materials;
    public MeshRenderer MeshRenderer;
    void Start() {
        MeshRenderer = gameObject.GetComponent<MeshRenderer>();        
    }
    void Update() {
        int requredMaterialIndex = 1; //this is just test value
        MeshRenderer.materials[1] = Materials[requredMaterialIndex];   
    }
