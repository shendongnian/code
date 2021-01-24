csharp
public class DisplayManager : MonoBehaviour
{
    public GameObject DisplayPanel;
    public Text Message_Text;
    public Button Complete_Button;
    private Queue<string> _messages;
    public void DoDisplay(string displayMessage)
    {
        //if no messages are displayed, you display the message 
        if (string.IsNullOrEmpty(Message_Text.text)) ShowMessage(displayMessage);
        //if other messages are displayed you enqueue the message
        else _messages.Enqueue(displayMessage);
    }
    private void ShowMessage(string displayMessage)
    {
        // Activate Panel, if not already active
        if(!DisplayPanel.activeSelf) DisplayPanel.SetActive(true);
        // set the message on the text
        Message_Text.text = displayMessage;
    }
    // A simple Button press to clear the flag
    public void OnComplete()
    {
        //if we have other messages we show the next
        if (_messages.Count > 0) ShowMessage(_messages.Dequeue());
        //otherwise we close the menu
        else CloseMessage();
    }
    private void CloseMessage()
    {
        Message_Text.text = "";
        DisplayPanel.SetActive(false);
    }
}
