     <Popup x:Name="PopupTest" AllowsTransparency="True">
                <Viewbox VerticalAlignment="Top">
                    <TextBlock Text="Wow, that was easy!"/>
                </Viewbox>
            </Popup>
      private void Button_Click(object sender, RoutedEventArgs e)
            {
                PopupTest.Placement = System.Windows.Controls.Primitives.PlacementMode.Mouse;
                PopupTest.StaysOpen = true;
                PopupTest.Height = 1000;
                PopupTest.Width = 500;
                PopupTest.IsOpen = true;
               
            }
