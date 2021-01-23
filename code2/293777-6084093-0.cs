        fb.GetCompleted +=
        (o, e) =>
        {
            if (e.Error == null)
            {
                var result = (IDictionary<string, object>)e.GetResultData();
                Dispatcher.BeginInvoke(() => InfoBox.ItemsSource = result);
            }
            else
            {
                // TODO: Need to let the user know there was an error
            }
        };
        fb.GetAsync("/me");
