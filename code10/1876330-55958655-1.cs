C#
public async void AcceptButton()
{
  this.IsEnabled = false;
  await this.httpDataService.Register(account);
  Show.SuccesBox(alert);
  this.TryClose();
}
You should add the `IsEnabled` property to your view model class and then bind it to the `IsEnabled` property of the view.
Disabling the window is nicer to the user than an unresponsive application, because this approach allows the user to minimize it or move it out of the way if it is taking an unexpectedly long time.
