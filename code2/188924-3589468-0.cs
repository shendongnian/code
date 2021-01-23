        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            string abc = "ABC";
            var p = new Paragraph();
            var bgw = new BackgroundWorker();
            String def = null;
            Run r = null;
            bgw.DoWork += (s1, e2) =>
              {
                  def = "DEF";
                  button.Dispatcher.BeginInvoke(new Action(delegate{r = new Run("blah");}));
              };
            bgw.RunWorkerCompleted += (s2, e2) =>
              {
                  abc = abc + def;
                  Console.WriteLine(abc); 
                  var l = new List<String> { def };
                  p.Inlines.Add(r);  // Calling thread can now access this object because 
                                     // it was created on the same thread that is updating it.
              };
            bgw.RunWorkerAsync();
        }
