    // The possible names of your cube sides
    public enum CubeSideName
    {
        X_l,
        X_u,
        Y_l,
        Y_u,
        Z_l,
        Z_u
    }
    
    // This stores the relationship between one certain
    // position (Front,Back,Top,Bottom,Right,Left)
    // and a cube side (x_l, x_u, y_l, y_u, z_l, z_u)
    [Serializable]
    public struct CubeSidePair
    {
        // For the example I used GameObjects with according names
        // instead of GameObjects you could also simply have a string ID or another enum 
        // for the name of the according position
        public GameObject GameObject;
        public CubeSideName Name;
    }
    
    
    [Serializable]
    public class Cube
    {
        // This stores which position (Front,Back,Top,Bottom,Right,Left)
        // is currently taken by which cube side (x_l, x_u, y_l, y_u, z_l, z_u)
        public CubeSidePair[] CubeSidesPair = new CubeSidePair[6];
    
        public Vector3Int Rotation
        {
            get { return _rotation; }
            set
            {
                UpdateRotation(value);
            }
        }
    
        // This is actually just for making it visual
        private readonly Dictionary<CubeSideName, Color> colors = new Dictionary<CubeSideName, Color>(6)
        {
            {CubeSideName.X_u, Color.blue },
            {CubeSideName.X_l, Color.cyan },
    
            {CubeSideName.Y_u, Color.red },
            {CubeSideName.Y_l, Color.magenta },
    
            {CubeSideName.Z_u,Color.green },
            {CubeSideName.Z_l,Color.yellow }
        };
    
        [Header("Debug only")]
        [SerializeField] private Vector3Int _rotation;
    
    
        public void Reset()
        {
            _rotation = Vector3Int.zero;
    
            CubeSidesPair[0].Name = CubeSideName.X_l;
            CubeSidesPair[1].Name = CubeSideName.Z_u;
            CubeSidesPair[2].Name = CubeSideName.Y_l;
            CubeSidesPair[3].Name = CubeSideName.Z_l;
            CubeSidesPair[4].Name = CubeSideName.Y_u;
            CubeSidesPair[5].Name = CubeSideName.X_u;
    
            UpdateColors();
        }
    
        // Here all the magic happens
        private void UpdateRotation(Vector3Int newRottaion)
        {
            // get difference to current rotation
            var newRotationInput = newRottaion - _rotation;
    
            // Go in 90° steps around the according axis
            // untilt he rotation is done
            while (newRotationInput != Vector3Int.zero)
            {
                // For each rotation step just take the index matrices from before
                // and use them to perform an array shift
                if (newRotationInput.x < 0)
                {
                    // do negative X rotation
                    var temp = CubeSidesPair[1].Name;
                    CubeSidesPair[1].Name = CubeSidesPair[2].Name;
                    CubeSidesPair[2].Name = CubeSidesPair[3].Name;
                    CubeSidesPair[3].Name = CubeSidesPair[4].Name;
                    CubeSidesPair[4].Name = temp;
    
                    newRotationInput.x += 90;
                }
                else if (newRotationInput.x > 0)
                {
                    // do positive X rotation
                    var temp = CubeSidesPair[4].Name;
                    CubeSidesPair[4].Name = CubeSidesPair[3].Name;
                    CubeSidesPair[3].Name = CubeSidesPair[2].Name;
                    CubeSidesPair[2].Name = CubeSidesPair[1].Name;
                    CubeSidesPair[1].Name = temp;
    
                    newRotationInput.x -= 90;
                }
                else if (newRotationInput.y < 0)
                {
                    // do negative Y rotation
                    var temp = CubeSidesPair[1].Name;
                    CubeSidesPair[1].Name = CubeSidesPair[0].Name;
                    CubeSidesPair[0].Name = CubeSidesPair[3].Name;
                    CubeSidesPair[3].Name = CubeSidesPair[5].Name;
                    CubeSidesPair[5].Name = temp;
    
                    newRotationInput.y += 90;
                }
                else if (newRotationInput.y > 0)
                {
                    // do positive Y rotation
                    var temp = CubeSidesPair[3].Name;
                    CubeSidesPair[3].Name = CubeSidesPair[0].Name;
                    CubeSidesPair[0].Name = CubeSidesPair[1].Name;
                    CubeSidesPair[1].Name = CubeSidesPair[5].Name;
                    CubeSidesPair[5].Name = temp;
    
                    newRotationInput.y -= 90;
                }
                else if (newRotationInput.z < 0)
                {
                    // do negative Z rotation
                    var temp = CubeSidesPair[3].Name;
                    CubeSidesPair[3].Name = CubeSidesPair[0].Name;
                    CubeSidesPair[0].Name = CubeSidesPair[1].Name;
                    CubeSidesPair[1].Name = CubeSidesPair[5].Name;
                    CubeSidesPair[5].Name = temp;
    
                    newRotationInput.z += 90;
                }
                else if (newRotationInput.z > 0)
                {
                    // do positive Z rotation
                    var temp = CubeSidesPair[3].Name;
                    CubeSidesPair[3].Name = CubeSidesPair[0].Name;
                    CubeSidesPair[0].Name = CubeSidesPair[1].Name;
                    CubeSidesPair[1].Name = CubeSidesPair[5].Name;
                    CubeSidesPair[5].Name = temp;
    
                    newRotationInput.z -= 90;
                }
            }
    
            _rotation = newRottaion;
    
            // just for the visual
            UpdateColors();
        }
    
        // Just for the visual
        private void UpdateColors()
        {
            foreach (var cubeSide in CubeSidesPair)
            {
                var renderer = cubeSide.GameObject.GetComponent<Renderer>();
    
                renderer.material.color = colors[cubeSide.Name];
            }
        }
    }
    
