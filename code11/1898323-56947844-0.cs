private void Draw()
{
  string[] data = new string[] { "Button1", "Button1", "Button1", "Button1", "Button1", "Button1", "Button1", "Button1", "Button1" };
  for (int i = 0; i < 5; i++)
  {
    var grid = new Grid
    {
       BackgroundColor = Color.Green
    };
    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(50) });
    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(50) });
    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
 
    var fButton = new Button { Text = "B", HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.Start, WidthRequest = 50, HeightRequest = 50 };
           
    grid.Children.Add(fButton, 0, 0);
         
    var equals = new Label { Text = "=>", VerticalTextAlignment = TextAlignment.Center, HorizontalTextAlignment = TextAlignment.Center, VerticalOptions = LayoutOptions.Start, WidthRequest = 50, HeightRequest = 50, BackgroundColor = Color.LemonChiffon };
    grid.Children.Add(equals, 1, 0);
    var flexLayout = new FlexLayout
    {
       Wrap = FlexWrap.Wrap,
       JustifyContent = FlexJustify.SpaceAround,
       AlignItems = FlexAlignItems.Start,
       AlignContent = FlexAlignContent.Start,
       BackgroundColor = Color.Red,
       HorizontalOptions = LayoutOptions.FillAndExpand,
    };
 
    foreach (var term in data)
    {
      var button = new Button { Text = term, HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.Start, HeightRequest = 36 };
      flexLayout.Children.Add(button);
      var label = new Label { Text = "and", VerticalTextAlignment = TextAlignment.Center, HorizontalTextAlignment = TextAlignment.Center, VerticalOptions = LayoutOptions.Start, HeightRequest = 50, BackgroundColor = Color.LemonChiffon };
      flexLayout.Children.Add(label);
     }
     grid.Children.Add(flexLayout, 2, 0);
     RootPanel.Children.Add(grid);
  }
}
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/GK0Um.gif
