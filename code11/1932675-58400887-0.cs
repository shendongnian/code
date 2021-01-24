    public class LabelsTest : MonoBehaviour
    {
        [SerializeField]
        private Text nameLabel;
    
        // Update is called once per frame
        void Update()
        {
            Vector3 cameraPos = Camera.main.WorldToScreenPoint(transform.position);
            nameLabel.transform.position = cameraPos; 
            nameLabel.enabled = cameraPos.z>0;
        }
    }
