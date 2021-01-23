    public class ChatMessageCollection : ObservableCollection<ChatMessage>
    {
      protected override void InsertItem(int index, ChatMessage item)
      {
        if (index > 0)
          item.IsConcatenated = (this[index - 1].Username == item.Username);
    
        base.InsertItem(index, item);
      }
    }
