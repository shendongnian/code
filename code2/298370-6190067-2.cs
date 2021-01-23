    public MyListener
    {
        public MyListener(MyServer server)
        {
            // Sets MyListenerMethod to be called when DataArrived is raised
            server.DataArrived += MyListenerMethod;
        }
    
        public void MyListener(string data)
        {
            // Do something with the data
            Console.WriteLine(data);
        }
    }
