    public class MyGird: Grid
    {
        Label first;
        Label second;
        Label third;
        Label fourth;
        public MyGird()
        {
            this.BindingContextChanged += MyGird_BindingContextChanged;
            for(int i = 0; i < 8; i++)
            {
                RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            }
            for (int i = 0; i < 8; i++)
            {
                ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }
            first = new Label { };
            second = new Label {  };
            third = new Label { };
            fourth = new Label {  };
            Children.Add(first, 0, 0);
            Children.Add(second, 2, 2);
            Children.Add(third, 5, 2);
            Children.Add(fourth, 7, 0);
        }
        private void MyGird_BindingContextChanged(object sender, EventArgs e)
        {
            var grid = sender as Grid;
            var obj = grid.BindingContext as List<string>;
            first.Text = obj[0];
            second.Text = obj[1];
            third.Text = obj[2];
            fourth.Text = obj[3];
        }
    }
