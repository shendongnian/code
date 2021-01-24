            Context Context = DependencyService.Get<AndroidPropertyHandler>().GetMainActivityContext();
            var Activity = (Activity) Context;
            Runnable MyRunnable = new Runnable(() => {
                Debug.WriteLine("My work goes here...");
            });
            Activity.RunOnUiThread(MyRunnable);
