cs
public class ChatViewModel : BaseViewModel
{
    private readonly Chat _chat;
    public ChatViewModel(Chat chat)
    {
        _chat = chat;
    }
    public Message LastMessage
    {
        get => _chat.LastMessage;
        set
        {
            _chat.LastMessage = value;
            PropertyChanged?.Invoke("LastMessage");
        }
    }
    ...
}
