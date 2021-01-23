    Message message;
    while(GetMessage(&message))
    {
        ProcessMessage(message);
    }
