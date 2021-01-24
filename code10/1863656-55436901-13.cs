    private async void MyDialog_Load(object sender, EventArgs e)
    {
        TaskObject owner = this.Owner as TaskObject;
        var progress = new Progress<string>(s => when_LongFunction_does_something_interesting(s));
        await owner.LongFunction(progress);
        when_task_completes();
    }
    void when_LongFunction_does_something_interesting(string message)
    {
        this.MyTextBox.Text = message;
    }
