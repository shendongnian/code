C#
public async void AcceptButton()
{
  this.IsEnabled = false;
  await this.httpDataService.Register(account);
  Show.SuccesBox(alert);
  this.TryClose();
}
Disabling the window is nicer to the user than an unresponsive application, because this approach allows the user to minimize it or move it out of the way if it is taking an unexpectedly long time.
