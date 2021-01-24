        hash = PhotonNetwork.CurrentRoom.CustomProperties;
        object temp;
        string key = rpk.activeGame;
        if (hash.TryGetValue(key, out temp))
        {
            if (temp is bool)
            {
                bool activeGame = (bool)temp;
            }
            else
            {
                // unexpected custom property value type
            }
        } 
        else 
        {
            // custom property not found
        }
