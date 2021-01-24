    public partial class MainWindow : Window
    {
      public MainWindow()
      {
        InitializeComponent();
      }
    
      public async void ComputeListener(object sender, RoutedEventArgs args)
      {
        // Don't block while waiting for Dispatcher to execute the action
        await Dispatcher.InvokeAsync(() => StatusBlock.Text = "Status: Processing");
            
        // Executes asynchronously on a background thread (thread pool thread).
        // Use for CPU bound operations
        await ComputeOnNewBackgroundThreadAsync();
    
        // Executes asynchronously on the current thread.
        // Use for lightweight async operations 
        Task task = new Task(ComputeOnCurrentUiThread);
        task.Start();
        await task;
        // Waiting for tasks example
        var tasks = new List<Task>();
        Task currentThreadTask = new Task(ComputeOnCurrentUiThread);
        currentThreadTask.Start();
        tasks.Add(currentThreadTask);
        Task backgroundThreadTask = ComputeOnNewBackgroundThreadAsync();
        tasks.Add(backgroundThreadTask);
     
        // Wait asynchronously for both Task instances to complete
        await Task.WhenAll(tasks);
      }
    
      private async Task ComputeOnNewBackgroundThreadAsync()
      {
        await Task.Run(
          () =>
          {
            //code here
          });
      }
    
      private void ComputeOnCurrentUiThread()
      {
        //code here
      }
    }
