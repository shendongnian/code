    public Form1()
    {
        InitializeComponent();
        this.OnFormClosingAsync(Window_FormClosingAsync);
    }
    async Task Window_FormClosingAsync(object sender, FormClosingAsyncEventArgs e)
    {
        e.HideForm = true; // Optional
        e.Timeout = 5000; // Optional
        await KMApplication.License.ShutDown();
        //e.Cancel = true; // Optional
    }
