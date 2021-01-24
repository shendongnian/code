        PlayerController _PlayerController; 
    void Start() {
     
	     GameObject Player = GameObject.Find("Player"); 
	     _PlayerController = Player.GetComponent<PlayerController>();
      
      } 
      public void UpgradeSpeed() // I changed the name according to its functionality 
      {
      	 _PlayerController.speed++; 
      }
