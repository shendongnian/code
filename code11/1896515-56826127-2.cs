    public class PickupObject : MonoBehaviour
    {
        virtual void Pickup(Player playerObject) { }
    }
    public class Coin : PickupObject 
    {
        public int price;
        override void Pickup(Player playerObject)
        {
            playerObject.money += price; // Move money over to the player as it probably makes more sense
        }
    }
    public class HealthPack : PickupObject 
    {
        public int healthRestored;
        override void Pickup(Player playerObject)
        {
            playerObject.health += healthRestored;
        }
    }
    public class PickupMagnet : MonoBehaviour
    {   
        public Player PlayerObject;
        private void Update()
        {
            PickupObject item = FindClosestItemInRange();
            Pickup(item);
        }
    
        private void Pickup(PickupObject pickup)
        {
                pickup.Pickup(PlayerObject);
                Destroy(pickup.gameObject);
        }   
    }
