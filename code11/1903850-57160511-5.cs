    private Bubble GetOneBubbleAtPosition(Vector3 position, Bubble.Type type = Bubble.Type.None) // Bubble Generation Function
    {
        //var go = Instantiate(ball, position, Quaternion.identity) as GameObject;
        var go = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefebs", "ball") , position, Quaternion.identity) as GameObject;
    
        if (type == Bubble.Type.None)
        {
            type = Bubble.GetRandomColorFromList(_grid.GetAllUniqueTypes());
        }
    
        // The RPC call
        PV.RPC("SetSprite", RpcTarget.AllBuffered, PhotonView.Get(go).ViewID, type);
    
        return bubble;
    }
