        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var view = new GridView();
            view.Columns.Add(new GridViewColumn { Header = "First Name", DisplayMemberBinding = new Binding("First") });
            view.Columns.Add(new GridViewColumn { Header = "Last Name", DisplayMemberBinding = new Binding("Last") });
            codeListView.View = view;
            codeListView.Items.Add(new { First = "Bill", Last = "Smith" });
            codeListView.Items.Add(new { First = "Jane", Last = "Doe" });
        }
