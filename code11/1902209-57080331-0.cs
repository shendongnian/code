 public class MyPage: Window
    {
       this.WindowStyle = WindowStyle.SingleBorderWindow;  
       //Add grid  
       this.RootGrid = new Grid()
       {
           //Add TextBox
           TextBox TextBox_Test = new TextBox()
            { Text = "ABC",
              Background = Brushes.Yellow, 
              HorizontalAlignment = HorizontalAlignment.Center, 
              VerticalAlignment = VerticalAlignment.Top 
            };
            this.RootGrid.Children.Add(TextBox_Test);
       }
    }
You can add rows/columns the same way. 
this.RootGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(20) });
this.RootGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width= new GridWidth(20) });
 
Then you can navigate to `MyPage` page as I told.  
Hope this helps.
