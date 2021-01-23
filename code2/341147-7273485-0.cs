    private void DoTrace_Click(object sender, RoutedEventArgs e)
        {
           foreach(var traceNode in _tracertWrapper.Results)
           {
              ((App)Application.Current).TracertResultNodes.Add(traceNode);
           }
    
           _tracertWrapper.DoTrace("8.8.8.8", 30, 50);
        }
