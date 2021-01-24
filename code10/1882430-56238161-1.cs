csharp
public class YourPlayer : Photon.MonoBehaviour
{
	public void Start()
	{
		//stop assigning controls if this is not the player related to this peer
		if(!photonView.IsMine) return;
		player.GetComponent<FireFighterHeroController>().enabled = true;
		player.GetComponent<CameraControler>().enabled = true;
		player.GetComponent<CameraControler>().SetTarget(player.transform);
	}
}
**ADD THE CHECK IN THE MANAGER**
--------------------------------
I'm not sure about all the logic of your code. Some code should apply to all players, some other code should apply only to Peer Related player.
I think you should just change the Start method like so:
    public void Start()
    {
    	GameObject player = PhotonNetwork.Instantiate(this.playerPrefab.name, spawnPoint.position, Quaternion.identity);
    	
    	//stop assigning controls if this is not the player related to this peer
    	if(!player.GetPhotonView().IsMine) return;
    	player.GetComponent<FireFighterHeroController>().enabled = true;
    	player.GetComponent<CameraControler>().enabled = true;
    	player.GetComponent<CameraControler>().SetTarget(player.transform);
    }
Further info: [Player Networking - Photon PUN](https://doc.photonengine.com/en-us/pun/current/demos-and-tutorials/pun-basics-tutorial/player-networking)
