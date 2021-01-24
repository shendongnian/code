    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(Host + uri))
        {
            yield return webRequest.SendWebRequest();
            response = webRequest.downloadHandler.text;
        }
    }
method:
    public IEnumerator GetID(string entity, string identify, string ID, Action<int> onComplete)
    {
        yield return StartCoroutine(GetRequest(entity + identify));
        var json = ParseJson(response);
        onComplete(int.Parse(json[ID]));
    }
And call him
    public void CreateRoom()
    {
        TypedLobby sqlLobby = new TypedLobby("myLobby", LobbyType.SqlLobby);
        string sqlLobbyFilter = "C0";
        SetNickName(userName.text);
        RoomOptions roomOptions = new RoomOptions
        {
            MaxPlayers = 5,
            CustomRoomProperties = new ExitGames.Client.Photon.Hashtable() { { sqlLobbyFilter, "0" } },
            CustomRoomPropertiesForLobby = new string[] { sqlLobbyFilter }
        };
        if (roomName.text.Length != 0)
        {
            client.PostRoom(roomName.text);
            var roomID = client.GetID("Rooms/", roomName.text, "IDRoom", 
                    delegate(int roomID) { 
                        client.PostPlayer(PhotonNetwork.NickName, roomID);
                        PhotonNetwork.CreateRoom(roomName.text, roomOptions, sqlLobby);
                    });
        }
        else notice.EmptyRoomName();
    }
