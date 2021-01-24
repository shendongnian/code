    [PunRPC]
    private void SetSprite(int viewID, Bubble.Type type)
    {
        var pv = PhotonView.Find(viewID);
        pv.transform.localScale = new Vector3(25f, 25f, 1.0f);
    
        SpriteRenderer render = pv.GetComponent<SpriteRenderer>();
        render.sprite = getBubbleSprite (type);
    
        Bubble bubble = pv.GetComponent<Bubble>();
        bubble.type = type;
    }
