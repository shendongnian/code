      public static class ButtonExtension
        {
            public static Button Clone(this Button myButton, int index)
            {
                var newButton = new Button
                                    {
                                        Command = myButton.Command,
                                        Style = myButton.Style,
                                        Name = myButton.Name + index,
                                        Visibility = myButton.Visibility,
                                        Padding = myButton.Padding,
                                        Margin = myButton.Margin,
                                        IsEnabled = myButton.IsEnabled,
                                        Height = myButton.ActualHeight,
                                        Width = myButton.ActualWidth
                                    };
                  return newButton;
            }
        }
