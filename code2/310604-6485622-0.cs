    class ....
    {
        WebClient webClient;
    
        private void Download_Click(object sender, EventArgs e)
        {
            webClient = new WebClient();
        }
        
        
        private void Button1_Click(object sender, EventArgs e)
        {
            webClient.CancelAsync();
        }
    
