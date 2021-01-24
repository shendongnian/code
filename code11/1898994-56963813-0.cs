    public class CustomCell : ViewCell
    {
        public ObservableCollection<TaskViewModel> Taken { get; set; }
        public CustomCell()
        {
            Taken = new ObservableCollection<TaskViewModel>();
            StackLayout cell = new StackLayout()
            {
                HeightRequest = 120,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.FillAndExpand,
                WidthRequest = 360,
            };
            StackLayout left = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.Center,
            };
            Label name = new Label()
            {
                FontSize = 8,
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalOptions = LayoutOptions.Center,
                VerticalTextAlignment = TextAlignment.Center,
            };
            Label team = new Label()
            {
                FontSize = 5,
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalOptions = LayoutOptions.Center,
                VerticalTextAlignment = TextAlignment.Center,
            };
            Check check = new Check();
            check.DisplayStyle = CheckDisplayStyle.Default;
            check.HorizontalOptions = LayoutOptions.End;
            check.VerticalOptions = LayoutOptions.Center;
            check.Toggled += (s, e) =>
            {
                getTasks.Taken.Remove((s as Check).BindingContext as Taken);
            };
            //Set Binding
            name.SetBinding(Label.TextProperty, new Binding("Name"));
            team.SetBinding(Label.TextProperty, new Binding("Team"));
            View = cell;
            cell.Children.Add(left);
            left.Children.Add(name);
            left.Children.Add(team);
            cell.Children.Add(check);
        }
    }
