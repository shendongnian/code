    public ObservableCollection<ChatMessage> ChatMessages
    {
        get;
        set;
    }
    public MainWindow()
    {
        InitializeComponent();
        ChatMessages = new ObservableCollection<ChatMessage>();
        ChatMessages.CollectionChanged += ChatMessages_CollectionChanged;
    }
    void ChatMessages_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        ArrayList itemTemplate = flowDocument.TryFindResource("blocksTemplate") as ArrayList;
        if (e.Action == NotifyCollectionChangedAction.Add)
        {
            foreach (ChatMessage chatMessage in e.NewItems)
            {
                foreach (Block block in itemTemplate)
                {
                    bool addBlock = true;
                    int index = ChatMessages.IndexOf(chatMessage);
                    if (block.Name == "fullHeader" &&
                        (index > 0 && ChatMessages[index].Sender == ChatMessages[index - 1].Sender))
                    {
                        addBlock = false;
                    }
                    else if (block.Name == "smallHeader" &&
                             (index == 0 || ChatMessages[index].Sender != ChatMessages[index - 1].Sender))
                    {
                        addBlock = false;
                    }
                    if (addBlock == true)
                    {
                        block.DataContext = chatMessage;
                        flowDocument.Blocks.Add(block);
                    }
                }
            }
        }
    }
