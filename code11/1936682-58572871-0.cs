    public class Inventory : MonoBehaviour
    {
        private bool carryingItem => pickedUpItem == null;
        private PickableItem pickedUpItem;
        [SerializeField] private Vector2 throwingForce;
        [SerializeField] private Transform spawnPosition; //Should be a child of the player gameobject. This will be position of the object
        [SerializeField] private Transform handTransform; //Should also be a child of the player gameobject. This needs to be animated for the keyframes that move the hand
    
        void Update()
        {
            if (carryingItem && Input.GetMouseButtonDown(1))
            {
                pickedUpItem.transform.SetParent(null);
                pickedUpItem.transform.position = spawnPosition.position;
                pickedUpItem.GetComponent<Rigidbody2D>().AddForce(transform.right * throwingForce.x + transform.up * throwingForce.y);
                pickedUpItem = null;
            }
        }
    
        private void OnCollisionEnter2D(Collision2D other)
        {
            var pickable = other.transform.GetComponent<PickableItem>();
            if (pickable && pickedUpItem == null) //This kind of depends on the game design because maybe you want to pick it up if you're carrying something already
            {
                pickedUpItem = pickable;
                pickable.transform.SetParent(handTransform);
            }
    
            pickable.transform.localPosition.Set(0,0,0);
        }
    }
