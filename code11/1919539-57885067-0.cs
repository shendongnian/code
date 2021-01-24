Parallel.ForEach(ipAddress, (item, loopState) =>
{
  Ping ping = new Ping();
  PingReply pingReply = ping.Send(ipAddress[i].ToString());
  Dispatcher.BeginInvoke((Action)delegate()
  {
    pictureBoxList[i].BackColor = (pingReply.Status == IPStatus.Success) ? Color.Green : Color.Red;
  });      
});
