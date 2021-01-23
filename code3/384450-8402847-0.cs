    WebClient client;
    public void download() {
        client = new WebClient();
        // Further code...
    }
    public void cancel() {
        client.CancelAsync();
    }
