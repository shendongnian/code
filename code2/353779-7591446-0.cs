    class token {
        ClientContext theClient; // this is the client we've observed activity on
        DateTime  theTime;       // this is the time of observed activity
    };
    class ClientContext {
        // ... what you need to know about the client
        DateTime lastActivity;   // the time the last activity happened on this client
    }
