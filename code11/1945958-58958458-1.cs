    public class DrawLineScript : MonoBehaviour
    {
        // Make this directly of type UpdateLineRenderer
        // this way you don't need GetComponent later
        public UpdateLineScript prefab;
    
        public void DrawLine(GameObject parent, GameObject child)
        {
            if(parent.name == "Spawner") return;
            var newLine = Instantiate(obj, parent.transform);   
    
            // Here you pass in all required information
            newLine.Initialize(parent.transform, child.transform, "Line " + child.name);
        }
    }
