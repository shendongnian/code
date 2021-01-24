    public class Ground : MonoBehaviour
    {
        public CellData cells;
    
        private void Start()
        {
            Debug.Log(cells);
        }
    }
    [CustomEditor(typeof(Ground))]
    public class GroundEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
    
            if (GUILayout.Button("Refresh Cell References"))
            {
                Ground ground = (Ground)target;
    
                ground.cells.cellReferences = new List<CellData.CellReference>();
    
                foreach (Transform groundCell in ground.transform)
                {
                    Cell cell = groundCell.GetComponent<Cell>();
    
                    if (cell != null)
                    {
                        Vector3 cellPosition = groundCell.position;
                        Vector2Int cellIndices = new Vector2Int(Mathf.RoundToInt(cellPosition.x), Mathf.RoundToInt(cellPosition.z));
    
                        ground.cells.cellReferences.Add(new CellData.CellReference(cellIndices, cell));
                    }
                }
            }
        }
    }
