    public class CellsData : MonoBehaviour
    {
        [System.Serializable]
        public class CellReference
        {
            public Vector2Int position;
            public Cell cell;
    
            public CellReference(Vector2Int posVal, Cell celVal)
            {
                position = posVal; cell = celVal;
            }
        }
    
        public List<CellReference> cellReferences = new List<CellReference>();
    }
