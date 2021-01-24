    public void OnClickHeroButton()
    {
         HeroSelect();
         StartCoroutine (WaitAllReady ());   
     }
     private IEnumerator WaitAllReady()
     {
         yield return new WaitUntil (() => AllPlayersReady);
         PhotonNetwork.LoadLevel(3);
     }
