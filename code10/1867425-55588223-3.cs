    public List<BC_PlayerInfo> playerInfoList = new List<BC_PlayerInfo>();
    ...
    playerInfoList.Clear();
    var tournamentConfigs = JsonMapper.ToObject(jsonResponse)["data"]["tournamentConfigs"];
    foreach (JsonData tournamentConfig in tournamentConfigs)
    {
        var playerInfo = new BC_PlayerInfo(tournamentConfig);
        playerInfoList.Add(playerInfo);
    
        string _tournamentCode = playerInfo.TournamentCode;
        Debug.Log(_tournamentCode);
        TituloTorneo.text = _tournamentCode;
        string _description = playerInfo.Description;
        Debug.Log(_description);
        DescripcionTorneo.text = _description;
    }
