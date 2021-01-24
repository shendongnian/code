     private void userItem_Click(object sender, RoutedEventArgs e)
        {
            LayoutDocument ld = new LayoutDocument();
            ld.Title = "All Users";
            ld.ToolTip = "Manage all users";
            //selection changed event
            ld.IsSelectedChanged += Ld_IsSelectedChanged;
            ld.IsActiveChanged += Ld_IsSelectedChanged;
            Users users = new Users(ld);
            ld.Content = users;
            LayoutDocumentPane pane = ((todaysPayments.FindParent<LayoutDocumentPane>() ?? (panal.Children?[0] as LayoutDocumentPane)) ?? new LayoutDocumentPane());
            pane.Children.Add(ld);
            if (panal.ChildrenCount == 0)
            {
                panal.Children.Add(pane);
            }
            ld.IsSelected = true;
        }
