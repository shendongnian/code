private async void timer1_Tick(object sender, EventArgs e)
{
    await Task.Delay(1130);
    panel3.Width += 77;
    await Task.Delay(1130);
    panel3.Width += 77;
    label2.Text = "Starting...";
    await Task.Delay(1130);
    panel3.Width += 77;
    label2.Text = "Downloading data...";
    await Task.Delay(1356);
    panel3.Width += 77;
    label2.Text = "Checking data...";
    await Task.Delay(1356);
    panel3.Width += 79;
    label2.Text = "Ready to launch!";
    await Task.Delay(1356);
}
