    using System.Linq;
    ...
    private bool AllPlayersReady ()
    {
         return PhotonNetwork.PlayerList.All(player => player.CustomProperties["PlayerReady"]);
    }
