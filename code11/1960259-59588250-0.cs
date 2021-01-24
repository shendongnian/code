    public class PlayerInventoryUI : MonoBehaviour
    {
        //Inventory Instance
        static PlayerInventory inventory;
        void Start()
        {
            inventory = PlayerInventory.getInstance(); 
            //works because static methods are called from the class
        }
    }
