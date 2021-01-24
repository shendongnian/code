private async void Button1_Click(object sender, EventArgs e)
{
    string a = await Get2().ConfigureAwait(false);
    richTextBox1.AppendText(a);
}
public async Task<string> Get2()
{
    return await "https://raw.githubusercontent.com/SMAPPNYU/ProgrammerGroup/master/LargeDataSets/sample-tweet.raw.json".GetStringAsync().ConfigureAwait(false);
}
