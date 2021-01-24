c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayConversations : MonoBehaviour
{
    private static ConversationTrigger conversationTrigger;
    private static PlayConversations instance;
    private void Awake()
    {
        conversationTrigger = GetComponent<ConversationTrigger>();
        instance = this;
    }
    public static void AddConversationToPlay(int index)
    {
        ConversationTrigger.conversationsToPlay.Add(index);
    }
    public static void StartPlayConversationsCoroutine()
    {
        instance.StartCoroutine(conversationTrigger.PlayConversations());
    }
}
and the test script
c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BeginningCutscene : MonoBehaviour
{
    public DepthOfField dephOfField;
    // Update is called once per frame
    void Update()
    {
        if (dephOfField.dephOfFieldFinished == true)
        {
            PlayConversations.AddConversationToPlay(0);
            PlayConversations.AddConversationToPlay(1);
            PlayConversations.StartPlayConversationsCoroutine();
        }
    }
}
