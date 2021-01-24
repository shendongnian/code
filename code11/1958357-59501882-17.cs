    public void OnClickHeroButton()
    {
         HeroSelect();
         if (!PhotonNetwork.IsMasterClient) return;
         StartCoroutine (WaitAllReady ());   
     }
     private IEnumerator WaitAllReady()
     {
         yield return new WaitUntil (() => AllPlayersReady);
         PhotonNetwork.LoadLevel(3);
     }
