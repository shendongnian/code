Parallel.For(0, ipAddress.Count() - 1, (i, loopState) =>
{
  Ping ping = new Ping();
  PingReply pingReply = ping.Send(ipAddress[i].ToString());
  Dispatcher.BeginInvoke((Action)delegate()
  {
    pictureBoxList[i].BackColor = (pingReply.Status == IPStatus.Success) ? Color.Green : Color.Red;
  });      
});
