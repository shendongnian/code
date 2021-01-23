    public void updateMessage()
    {
        DateTime start = DateTime.Now;
    
        while (DateTime.Now.Subtract(start).Seconds < 15)
        {
            //do your update here
            textbox.text+="STATUS";
        }
    }
    Thread threadUpdating=new Thread(new ThreadStart(updateMessage));;
    threadUpdating.Start();
