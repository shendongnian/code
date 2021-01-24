    //Sender
    MessagingCenter.Send<object, DraggableView.DraggableView>(this, "EditSelectedText", dragView);
    
    
    //Subscriber
    MessagingCenter.Subscribe<object, DraggableView.DraggableView>(this, "EditSelectedText", async (sender, arg) =>
    {
        await EditSelectedText(arg);
    });
