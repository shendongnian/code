    public class PositionConverter : MonoBehaviour
    {
        public float edgesize;
    
        public Vector3 inputVector;
        // I used a transform here in order to simply drag around
        // the object in Unity (or set it via script)
        public Transform WorldSpacePosition;
        public Vector3 backtoRobot;
    
        // whether to automatically update backtoRobot using the WorldSpacePosition.localPosition;
        public bool autoupdate;
    
        private void Awake()
        {
            // I simply used the lossyScale.x as edgeSize
            edgesize = transform.lossyScale.x;
        }
    
        private void Update()
        {
            if(!autoupdate)return;
    
            UpdateRobotPosition();
        }
    
        [ContextMenu("UpdateWorldPosition")]
        private void UpdateWorldPosition()
        {
            WorldSpacePosition.localPosition = RobotToUnityPosition(inputVector);
        }
    
        [ContextMenu("UpdateRobotPosition")]
        private void UpdateRobotPosition()
        {
            backtoRobot = UnityToRobotPosition(WorldSpacePosition.localPosition);
        }
    
        private Vector3 RobotToUnityPosition(Vector3 input)
        {
            // first shift the values since 0 means e.g. -x edge etc
            var output = input;
            output.x -= 50;
            output.y -= 50;
            output.z -= 50;
    
            // now eliminate the factor 100
            output /= 100.0f;
    
            // finally scale it according to the cube's edgesize
            output *= edgesize;
    
            return output;
        }
    
        private Vector3Int UnityToRobotPosition(Vector3 input)
        {
            // basically do it the other way round
            var output = input;
    
            // Get percentages
            output /= edgesize;
    
            // scale it up to factor 100
            output *= 100;
    
            // shift the values back
            output.x += 50;
            output.y += 50;
            output.z += 50;
    
            // Now you might want to clamp the values
            output.x = Mathf.Clamp(output.x, 0, 100);
            output.y = Mathf.Clamp(output.y, 0, 100);
            output.z = Mathf.Clamp(output.z, 0, 100);
    
            // Finally you might want to get it as Vector3Int ? 
            // if not you can skip that and change the return type to Vector3
            return Vector3Int.FloorToInt(output);
        }
    
        // Just for drawing the WireCube for the bounds
        private void OnDrawGizmos()
        {
            edgesize = transform.lossyScale.x;
            Gizmos.matrix = transform.localToWorldMatrix;
    
            Gizmos.DrawWireCube(Vector3.zero, Vector3.one * edgesize);
        }
    }
