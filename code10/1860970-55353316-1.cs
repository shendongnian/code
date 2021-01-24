    public void GotData(LeaderboardDataResponse response)
    {
        if (!response.HasErrors)
        {
            foreach (var entry in response.Data)
            {
                int rank = (int)entry.Rank;
                string playerName = entry.UserName;
                string score = entry.JSONData["SCORE"].ToString();
                Debug.Log("Rank:" + rank + " Name:" + playerName + " \n Score:" + score);
            }
        }
        else
        {
            Debug.LogError(response.JSONData);
        }
    }
