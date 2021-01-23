    catch (Exception x)
                {
                    Deployment.Current.Dispatcher.BeginInvoke(() =>
                    {
                        var currentPage = ((App)Application.Current).RootFrame.Content as PhoneApplicationPage;
                        if ((currentPage.ToString()).Equals("MumbaiMarathon.Info.News"))
                        {
                            MessageBox.Show("Connection Error");
                        }
                    });
                }
