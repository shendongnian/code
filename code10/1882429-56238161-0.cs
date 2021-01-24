    public void Start()
    {
    	GameObject player = PhotonNetwork.Instantiate(this.playerPrefab.name, spawnPoint.position, Quaternion.identity);
    	
    	//stop assigning controls if this is not the player related to this peer
    	if(!photonView.IsMine) return;
    	player.GetComponent<FireFighterHeroController>().enabled = true;
    	player.GetComponent<CameraControler>().enabled = true;
    	player.GetComponent<CameraControler>().SetTarget(player.transform);
    }
