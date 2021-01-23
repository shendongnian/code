    Messenger.Default.Register<DialogMessage>(
             view,
             msg =>
             {
                 var result = MessageBox.Show(
                     msg.Content,
                     msg.Caption,
                     msg.Button,
                     msg.Icon);
             }
    );
