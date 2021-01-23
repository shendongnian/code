    	BackgroundWorker worker;
		Form dialogForm;
		private void buttonGeneratePassword_Click( object sender, EventArgs e )
		{
			worker = new BackgroundWorker();
			worker.DoWork += new DoWorkEventHandler( worker_DoWork );
			worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler( worker_RunWorkerCompleted );
			worker.RunWorkerAsync();
			dialogForm = new Form(); // dispay your dialog
			dialogForm.ShowDialog();
		}
		void worker_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e )
		{
			// password generated.. close dialog form
			dialogForm.Close();
		}
		void worker_DoWork( object sender, DoWorkEventArgs e )
		{
			// put generate password code here
			Thread.Sleep( 1000 ); // delete this line - it is only for testing flow without password generation code
		}
