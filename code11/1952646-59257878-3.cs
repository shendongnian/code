        private void AddTask(object sender, RoutedEventArgs e)
        {
            AddTask aT1 = new AddTask();
            DialogResult results = aT1.ShowDialog();
            if(results == DialogResult.OK)
            {
                List<string> listExt = aT1.ListExtension;
            }
        }
