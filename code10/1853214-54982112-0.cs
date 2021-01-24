    public class ShopButtons : MonoBehaviour
    {
        public Guid UniqueId { get; }
        public ShopButtons() 
        {
            UniqueId = Guid.NewGuid();
        }
        //etc...
    }
