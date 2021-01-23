     AddVendorModalityViewModel viewModel;
        var waitScreen = new Controls.Views.SampleView();
        var popUp = new ShellBlank();
        popUp.Content = waitScreen;
        popUp.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        var bw = new BackgroundWorker() { WorkerReportsProgress = true, WorkerSupportsCancellation = true };
        bw.DoWork += (s, e) =>
        {
          viewModel = container.Resolve<AddVendorModalityViewModel>();
          e.Result = viewModel;
        };
        bw.RunWorkerCompleted += (s, e) =>
        {
          viewModel = (AddVendorModalityViewModel)e.Result;
          AddVendorModalityView view = new AddVendorModalityView(viewModel);
          popUp.Content = view;
        };
        bw.RunWorkerAsync();
        popUp.ShowDialog();
