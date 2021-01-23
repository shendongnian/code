      //to be on the safe side first check
      if(this.Content == null || !(this.Content is Panel)
          return;
      foreach (var item in (this.Content as Panel).Children)
        {
            if (item is Button)
            {
                Button b = item as Button;
                b.Background = new SolidColorBrush(Colors.Red);
            }
        }
