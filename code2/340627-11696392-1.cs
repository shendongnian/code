    public class MyResource
    {
        // do this instead of a constructor
        public async Task<MyResource> StartAsync()
        {
            await Task.Delay(1);
            return this;
        }
    }
    public class MyControl
    {
        public MyResource Resource { get; set; }
        async void Button_Click(object s, EventArgs e)
        {
            // call start as if it is a constructor
            this.Resource = await new MyResource().StartAsync();
        }
    }
