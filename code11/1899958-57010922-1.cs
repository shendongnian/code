        // If you are a player, change the active buttons that are visible.
        if (PhotonNetwork.NickName == pOne || PhotonNetwork.NickName == pTwo) 
        {
            gameMenu.GetComponent<GameButtonManager> ().GameStart ();
        }
