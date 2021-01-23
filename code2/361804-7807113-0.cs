    private void ButtonSubmit_Click(object sender, EventArgs e) {
    =>
    private async void ButtonSubmit_Click(object sender, EventArgs e) {
    TextResponse.Text += Task.Factory.StartNew(() => PostSomeData().Wait());
    =>
    TextResponse.Text += await PostSomeData();
