    #if UNITY_EDITOR
    using UnityEditor;
    #endif
    
    public class PickupObjects : MonoBehaviour
    {
        [SerializeField]
        public List<GameObject> pickUpObjects = new List<GameObject>();
    
    #if UNITY_EDITOR
        [MenuItem("GameObject/Generate as Pickup Item", true, 30)]
        private static bool CanGeneratePickupItems()
        {
            return GameObject.FindObjectOfType<PickUpObjects>();
        }
    
        [MenuItem("GameObject/Generate as Pickup Item", false, 30)]
        private static void GeneratePickupItems()
        {
            var instance = FindObjectOfType<PickUpObjects>();
    
            if(!instance) return;
    
            // Clear the list first? Otherwise selection will be added to already existing entries
            // (Duplicates are filtered out later below anyway)
            instance.pickupObjects.Clear();
            if (Selection.gameObjects.Length <= 0) return;
            
            foreach (var selectedObj in Selection.gameObjects)
            {
                if (selectedObj.GetComponent<TestScript>() == null)
                {       
                    selectedObj.AddComponent<BoxCollider>();
                    selectedObj.AddComponent<TestScript>();               
                }
    
                selectedObj.layer = 9;
    
                if(!instance.pickupObjects.Contains(selectedObj)) instance.pickupObjects.Add(selectedObj);
            }
        }
    #endif
    }
