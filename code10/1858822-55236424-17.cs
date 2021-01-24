    [Serializable]
    public class JsonData
    {
        // here maybe int is ok at least from your data it seems so
        public List<Vector2Int> landmarks = new List<Vector2Int>();
        // for those you clearly want floats
        public List<Vector3> eulerAngles = new List<Vector3>();
        public List<Vector2> boxPoints = new List<Vector2>();
    }
    
