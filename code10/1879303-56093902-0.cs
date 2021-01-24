    public void NaviConversations(int Index)
    {
        scaling.scaleUp = true;
        op.Scaling(false);
        StartCoroutine(StartConversationAfterScaling(Index));
    }
    private IEnumerator StartConversationAfterScaling(int index)
    {
        yield return new WaitUntil(scalingIsDoneCondition);
        StartCoroutine(conversationTrigger.PlayConversation(Index));
    }
