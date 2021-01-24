    public void NaviConversations(int Index)
    {
        scaling.scaleUp = true;
        StartCoroutine(StartConversationAfterScaling(Index));
    }
    private IEnumerator StartConversationAfterScaling(int index)
    {
        yield return op.Scaling(false);
        StartCoroutine(conversationTrigger.PlayConversation(Index));
    }
