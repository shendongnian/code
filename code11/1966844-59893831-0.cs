    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        PlayersName();
    }
    public void PlayersName()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            playerNames[0].text = "Kingdom Player 1";
            playerNames[1].text = "";
        }
        else
        {
            playerNames[0].text = "Kingdom Player 1";
            playerNames[1].text = "Kingdom Player 2";
        }
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        PlayersName();
    }
