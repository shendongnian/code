    public static ArrayList eventObjects = new ArrayList(); //Declare a global array list which will be accessible from all classes
    eventObjects.Add(this); //Before calling AddNumber method
    _client.AddNumber += new EventHandler<AddNumberCompletedEventArgs>(_client_AddNumberCompleted);
    void _client_AddNumberCompleted(object sender, AddNumberCompletedEventArgs e)
    {
         if(ar.Contains(this))
         {
             //Do what you want to do here. Other classes will receive this event too, but they will not react.
             eventObjects.Remove(this);
         }
    }
