				using System;
				using System.Drawing;
				using MonoTouch.UIKit;
				using MonoTouch.Foundation;
				using System.Collections.Generic;
				using System.Threading.Tasks;
				namespace yournamespace
				{
					public enum MessageBoxResult
					{
						None = 0,
						OK,
						Cancel,
						Yes,
						No
					}
					public enum MessageBoxButton
					{
						OK = 0,
						OKCancel,
						YesNo,
						YesNoCancel
					}
					public static class MessageBox
					{
						public static Task<MessageBoxResult> ShowAsync(string messageBoxText, string caption, MessageBoxButton buttonType)
						{
							MessageBoxResult res = MessageBoxResult.Cancel;
							bool IsDisplayed = false;
							int buttonClicked = -1;
							MessageBoxButton button = buttonType;
							UIAlertView alert = null;
							string cancelButton = "Cancel";
							string[] otherButtons = null;
							switch (button)
							{
							case MessageBoxButton.OK:
								cancelButton = "";
								otherButtons = new string[1];
								otherButtons[0] = "OK";
								break;
							case MessageBoxButton.OKCancel:
								otherButtons = new string[1];
								otherButtons[0] = "OK";
								break;
							case MessageBoxButton.YesNo:
								cancelButton = "";
								otherButtons = new string[2];
								otherButtons[0] = "Yes";
								otherButtons[1] = "No";
								break;
							case MessageBoxButton.YesNoCancel:
								otherButtons = new string[2];
								otherButtons[0] = "Yes";
								otherButtons[1] = "No";
								break;
							}
							var tsc = new TaskCompletionSource<MessageBoxResult> ();
							if (cancelButton.Length > 0)
								alert = new UIAlertView(caption, messageBoxText, null, cancelButton, otherButtons);
							else
								alert = new UIAlertView(caption, messageBoxText, null, null, otherButtons);
							alert.BackgroundColor = UIColor.FromWhiteAlpha(0f, 0.8f);
							alert.Canceled += (sender, e) => {
								tsc.TrySetResult( MessageBoxResult.Cancel);
							};
							alert.Clicked += (sender, e) => {
								buttonClicked = e.ButtonIndex;
								switch (button)
								{
								case MessageBoxButton.OK:
									res = MessageBoxResult.OK;
									break;
								case MessageBoxButton.OKCancel:
									if (buttonClicked == 1)
										res = MessageBoxResult.OK;
									break;
								case MessageBoxButton.YesNo:
									if (buttonClicked == 0)
										res = MessageBoxResult.Yes;
									else
										res = MessageBoxResult.No;
									break;
								case MessageBoxButton.YesNoCancel:
									if (buttonClicked == 1)
										res = MessageBoxResult.Yes;
									else if (buttonClicked == 2)
										res = MessageBoxResult.No;
									break;
								}
								tsc.TrySetResult( res);
							};
							alert.Show();
							return tsc.Task;
						}
						public static Task<MessageBoxResult> ShowAsync(string messageBoxText)
						{
							return ShowAsync(messageBoxText, "", MessageBoxButton.OK);
						}
						public static Task<MessageBoxResult> ShowAsync(string messageBoxText, string caption)
						{
							return ShowAsync(messageBoxText, caption, MessageBoxButton.OK);
						}
					}
				}
