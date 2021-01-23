	public partial class MainWindow : Window {
		private void btnDoSomething_Click(object sender0, RoutedEventArgs e0) {
		
			_progressDialogue = new Progresser{Owner = _owner, StartPosition = FormStartPosition.CenterParent};
			_progressDialogue.Closed += ProgressDialogueClosed;
			_progressDialogue.Show();
		
			BackgroundWorker worker = new BackgroundWorker();
			worker.WorkerReportsProgress = true;
			worker.DoWork += delegate(object sender, DoWorkEventArgs e) {
				DoSomething();
				e.Result = result;
			};
			worker.ProgressChanged += delegate(object sender, ProgressChangedEventArgs e) {
				progressDialogue.Update()
			};
			worker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e) {
				progressDialogue.Close()
			};
			worker.RunWorkerAsync(new CustomArgs() {
				SomeValue = txtValue.Text,
			});
		}
	}
