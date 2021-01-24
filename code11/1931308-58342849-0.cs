    public static Task OnClickAsync(this Control source)
    {
        var tcs = new TaskCompletionSource<bool>();
        source.Click += OnClick;
        return tcs.Task;
        void OnClick(object sender, EventArgs e)
        {
            source.Click -= OnClick;
            tcs.SetResult(true);
        }
    }
