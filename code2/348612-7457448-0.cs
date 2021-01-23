    private string channel;
    public void OnPublic(UserInfo user, string channel, string message)
    {
       this.channel = channel;
       // etc...
    }
    private void button1_Click(object sender, EventArgs e)
    {
       // You can use this.channel here.
    }
