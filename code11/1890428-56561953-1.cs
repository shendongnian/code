    public class ObjectScript : MonoBehaviour
    {
        public CommonObjectPropertis commonProps;
        public Vector3 ObjectScriptSmallSphere;
    
        private void Start()
        {
            ObjectScriptSmallSphere = commonProps.SphereSmall;   
        }
    }
