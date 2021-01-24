using UnityEngine;
using System.Collections;
public class OnValidateExample : MonoBehaviour
{
	public List<Conversation> conversations;
    private int previousConversationsCount;
    private int currentConversationsCount;
 
	void OnValidate()
    {
        currentConversationsCount = conversations.Count();
        if (previousConversationsCount != currentConversationsCount)
		    Debug.Log($"Conversations count has changed: {previousConversationsCount} => {currentConversationsCount}");
        previousConversationsCount = currentConversationsCount;
	}
}
  [1]: http://cjf.in.ua/812-unity-editor-extensions-the-power-of-onvalidate/
