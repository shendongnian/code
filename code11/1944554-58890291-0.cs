    async void BtnRunClick(object sender, EventArgs e)
    {
        listBox1.Items.Clear();
        async Task longTaskHelperAsync() {
            // probably, Task.Run is redundant here,
            // could just do: var item = await LongTaskAsync();
            var item = await Task.Run(() => LongTaskAsync()); 
            listBox1.Items.Add(item);
        }
        async Task shortTaskHelperAsync() {
            // probably, Task.Run is redundant here, too
            var item = await Task.Run(() => ShortTaskAsync()); 
            listBox1.Items.Add(item);
        }
        await Task.WhenAll(longTaskHelperAsync(), shortTaskHelperAsync());
    }
