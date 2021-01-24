    [System.Serializable]
    public class CellData : MonoBehaviour
    {
        [System.Serializable]
        public class CellReference
        {
            public int xPos;
            public int yPos;
            public Cell cell;
    
            public CellReference(Vector2Int posVal, Cell celVal)
            {
                xPos = posVal.x; yPos = posVal.y; cell = celVal;
            }
        }
    
        public List<CellReference> cellReferences = new List<CellReference>();
    }
