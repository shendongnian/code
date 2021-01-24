    public class SkyBox : MonoBehaviour
    {
        public Material[] skyboxes;
    
        private int index;
    
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                index = (index + 1) % skyboxes.Length;
               
                RenderSettings.skybox = skyboxes[index];
            }
        }
    } 
