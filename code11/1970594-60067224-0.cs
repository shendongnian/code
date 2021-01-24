            private async void SearchTermEntered(object sender, string searchText)
            {
                //Refreshes the topics listbox as new values are entered
                SearchTerm = searchText.ToLower();
    
                stkPnlTopics.Visibility = Visibility.Collapsed;
                stkPnlMetrics.Visibility = Visibility.Collapsed;
                stkPnlResources.Visibility = Visibility.Collapsed;
    
                if (SearchTerm.Length <= 2) return;
                if (string.IsNullOrEmpty(SearchTerm))
                {
                    stkPnlTopics.Visibility = Visibility.Collapsed;
                    txtBlkTopics.Text = "";
                }
                else if (SearchTerm.IsNumeric() || GLSearchPatterns.Contains(SearchTerm))
                { 
                    //user is searching for a guideline
                    txtBlkTopics.Text = "Guidelines";
                    stkPnlTopics.Visibility = Visibility.Visible;
                }
                else
                {
                    await SearchAsync();
                }
    
                CollectionViewSource.GetDefaultView(lstBxTopics.ItemsSource).Refresh();
            }
    
            /// <summary>
            /// https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/task-based-asynchronous-programming
            /// </summary>
            private async Task SearchAsync()
            {
                CancellationSource = new CancellationTokenSource();
                try
                {
                    //SearchManager sMan = new SearchManager();
                    //System.Diagnostics.Debug.WriteLine("Starting Task");
                    //var results = await sMan.GetArtifactsWithSearchValAsync(SearchTerm, CancellationSource.Token);
                    //System.Diagnostics.Debug.WriteLine("Results: " + results.ToString());
    
                    System.Diagnostics.Debug.WriteLine("Starting Task");
                    await Task.Run(async () =>
                    {
                        decimal result = 0;
                        // Loop for a defined number of iterations
                        for (int i = 0; i < 100; i++)
                        {
                            // Check if a cancellation is requested, if yes,
                            // throw a TaskCanceledException.
                            CancellationSource.Token.ThrowIfCancellationRequested();
    
                            // Do something that takes times like a Thread.Sleep in .NET Core 2.
                            //Thread.Sleep(10);
                            await Task.Delay(10);
                            result += i;
                        }
    
                        System.Diagnostics.Debug.WriteLine("Result: " + result.ToString());
                    });
                }
                catch (OperationCanceledException)
                {
                    System.Diagnostics.Debug.WriteLine("Op cancelled exception.");
                }
            }
    
            private void CancelSearch(object sender, EventArgs e)
            {
                System.Diagnostics.Debug.WriteLine("Cancel Search");
                CancellationSource?.Cancel();
            }
