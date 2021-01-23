    public void OnAddMemberToTeamCompleted(object sender, EventArgs args)
    {
        _client.AddMemberToTeamCompleted -= OnAddMemberToTeamCompleted;
        callback(e.Result)
    }
