csharp
using Cinemachine;
public class GameMaster : MonoBehaviour
{
    public static GameMaster gm;
    public CinemachineVirtualCamera myCinemachine;
    void Start()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
        myCinemachine = GetComponent<CinemachineVirtualCamera>();
    }
    public Transform playerPrefab, spawnPoint;
    public int spawnDelay = 2;
    public void RespawnPlayer() {
        //yield return new WaitForSeconds(spawnDelay);
        var newPlayer = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        Debug.Log("ADD SPAWN PARITCAL");
        
        myCinemachine.m_Follow = newPlayer;
    }
    public static void Killplayer(Player player) {
        Destroy(player.gameObject);
        gm.RespawnPlayer();
    }
}
