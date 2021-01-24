    public class Upgrader1 : MonoBehaviour
    {
    
    PlayerController PlayerController; //It should be member variable
    void Start()
    {
        GameObject Player = GameObject.Find("Player");
        PlayerController = Player.GetComponent<PlayerController>();
    }
    
    public void Upgrade1()
    {
        PlayerController.speed++;
    }
    }
