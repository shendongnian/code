Parallel.For(0, ipAddress.Count() - 1, (i, loopState) =>
{
  Ping ping = new Ping();
  PingReply pingReply = ping.Send(ipAddress[i].ToString());
  Dispatcher.BeginInvoke((Action)delegate()
  {
    //for wpf
    pictureBoxList[i].BackColor = (pingReply.Status == IPStatus.Success) ? Color.Green : Color.Red;
    //for winform
    SetColor(pictureBoxList[i], pingReply.Status == IPStatus.Success);
  });      
});
//for winform delegate
delegate void SafeSetColor(PictureBox pb, bool success);
private void SetColor(PictureBox pb, bool success)
{
 if(pb.InvokeRequired)
 {
   SafeSetColor objSet=new SafeSetColor(SetColor);
   pb.Invoke(objSet,new object[]{pb, success});
 }
 else
 {
   pb.BackColor = (success) ? Color.Green : Color.Red;
 }
}
