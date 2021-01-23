    void EventHandler_A() {
        // Call Fish method on all clients:
        CallBackClients(client => client.Fish("hello"));
    }
    void EventHandler_B() {
        // Call SuperFish method on all clients:
        CallBackClients(client => client.SuperFish(10, 5.3);
    }
    
