C#
private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
{
       Close();
       SnippingWindow sw = new SnippingWindow();
       sw.ShowDialog();
}
private void Bw_DoWork(object sender, DoWorkEventArgs e)
{
     //Windows Opacity is bound to this value.
     //I had to implement iNotifyPropertyChanged on this property. 
     OpacityValue = 0;
}
