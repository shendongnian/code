    service1Client.GetDataCompleted += service1Client_GetDataCompleted;
    public void service1Client_GetDataCompleted(object sender, wsService1.GetDataCompletedEventArgs e)
    {
       string Data = e.Result.ToString();
    }
   
