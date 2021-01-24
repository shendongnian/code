    public IEnumerator NaviScaling()
    {
        if (scaling.objectToScale.transform.localScale == scaling.minSize)
        {
            op.Scaling();
        }
    
        while (scaling.objectToScale.transform.localScale != scaling.maxSize)
        {
            yield return null;
        }
    
        conversationTrigger.PlayConversations();
    
        while (!conversationTrigger.conversationEnd)
        {
            yield return null;
        }
    
        op.Scaling();
    }
