       public void Display(ISubView view)
       {
          contentHolder.Content = view;
          DataContext = view.ViewModel;
          Show();
       }
