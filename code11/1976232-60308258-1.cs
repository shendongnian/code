async Task LongRunningProcess()
{
    await Task.Delay(1000);
}
*In your loop*
public async void TextChangedEvent(object sender, EventArgs e)
{
  for (int i = 0; i < textBoxChildren.Count; i++)
  {
     txt.Background = Brushes.Red;
     await Task.Run(() => LongRunningProcess());
  }
}
