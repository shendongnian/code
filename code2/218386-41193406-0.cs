        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            new Thread(DoSomething).Start();
        }
        public void DoSomething()
        {
            for (int i = 0; i < 100000000; i++)
			{
			       this.Dispatcher.Invoke(()=>{
                   textbox.Text=i.ToString();
                   });    
			} 
        }
