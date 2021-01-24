    #if UNITY_EDITOR
    using UnityEditor;
    #endif
    
    public class PickupObjects : MonoBehaviour
    {
        [SerializeField]
        public List<GameObject> pickUpObjects = new List<GameObject>();
    
    #if UNITY_EDITOR
        [ContextMenu(nameof(GeneratePickupItems))]
        private void GeneratePickupItems()
        {
            if (Selection.gameObjects.Length > 0)
            {
                for (int i = 0; i < Selection.gameObjects.Length; i++)
                {
                    if (Selection.gameObjects[i].GetComponent<TestScript>() == null)
                    {
                        Selection.gameObjects[i].AddComponent<BoxCollider>();
                        Selection.gameObjects[i].AddComponent<TestScript>();
                    }
    
                    Selection.gameObjects[i].layer = 9;
                    pickUpObjects.Add(Selection.gameObjects[i];
                }
            }
        }
    #endif
    }
