    public class Example : MonoBehaviour
    {
        public EquipmentInventory equipmentInventory;
    
        [ContextMenu("Run")]
        public void Run()
        {
            equipmentInventory = EquipmentInventory.Instance;
        }
    }
