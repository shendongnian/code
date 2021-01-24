// Attach this script to the player object
public class DeadOrAlive : MonoBehaviour
{
    public GameObject deadPanel;
    
    void OnDestroy()
    {
        deadPanel.SetActive(true);
    }
}
You can also instead of destroying the player object, set it to active/inactive, but to check if the player is dead or alive this way, you will need a separate object which checks the active state:
//Attach this to a object which isn't a child of the player, maybe a dummy object called "PlayerMonitor" which is always active
public class DeadOrAlive : MonoBehaviour
{
    public GameObject deadPanel;
    void Update()
    {
        if (!GameObject.FindWithTag("Player"))
        {
            deadPanel.SetActive(true);
        }
    }
}
Haven't used unity in a while and forgot how weird it could get.
