    public class PowerUpObject : ScriptAbleObject
    {
        public GameObject Prefab;
    } 
    
    public class PowerUpManager : Monobehaviour
    {
        public List<PowerUpObject> PowerUps;
    
        public PowerUp GetRandomPowerUp()
        {
            if(PowerUps != null && PowerUps.Count > 0)
            {
                int randomIdx = Random.Range(0, PowerUps.Count);
                return PowerUps[randomIdx];
            }
            
            // error case
            Debug.Log("No PowerUps in List");
            return null;
        }
    }
