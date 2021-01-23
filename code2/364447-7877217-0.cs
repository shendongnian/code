			private void NavigateWeb()
			{
				  if (!loaded)
				  {
						NavigationStack.Clear();
						try
						{
							  Web.Source = new Uri("http://m.weightwatchers.com/");
							  loaded = true;
						}
						catch (Exception ex)
						{
							  MessageBox.Show("Unable to navigate to page.\n" + ex.Message,
									"Error", MessageBoxButton.OK);
						}
				  }
			}
			void Web_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
			{
				  NavigationStack.Push(e.Uri);
			}
			void btnBack_Click(object sender, EventArgs e)
			{
				  if (NavigationStack.Count > 2)
				  {
						// get rid of the topmost item...
						NavigationStack.Pop();
						// now navigate to the next topmost item
						// note that this is another Pop - as when the navigate occurs a Push() will happen
						Web.Navigate(NavigationStack.Pop());
				  }
			}
