    public static class SwitchCellTemplate
        {
            /// <summary>
            /// Attached property to buttons to close host window
            /// </summary>
            public static readonly DependencyProperty SwitchTemplate =
                DependencyProperty.RegisterAttached
                (
                    "CloseTemplate",
                    typeof(bool),
                    typeof(SwitchCellTemplate),
                    new PropertyMetadata(false, SwithcTemplateChanged)
                );
    
            public static bool GetSwitchTemplateProperty(DependencyObject obj)
            {
                return (bool)obj.GetValue(SwitchTemplate);
            }
    
            public static void SetSwitchTemplateProperty(DependencyObject obj, bool value)
            {
                obj.SetValue(SwitchTemplate, value);
            }
    
    
            public static void SwithcTemplateChanged(DependencyObject property, DependencyPropertyChangedEventArgs args)
            {
                if (property is Button)
                {
                    Button button = property as Button;
                    if (button != null) button.Click += OnClick;
                }
    
            }
    
            private static void OnClick(object sender, RoutedEventArgs e)
            {
                if (sender is Button)
                {
                    DataGrid dataGrid = FindParent<DataGrid>((Button)sender);
                    if (dataGrid != null)
                        dataGrid.CancelEdit();
                }
            }
    
            private static T FindParent<T>(DependencyObject dependencyObject) where T : DependencyObject
            {
                var parent = VisualTreeHelper.GetParent(dependencyObject);
    
                if (parent == null) return null;
    
                var parentT = parent as T;
                return parentT ?? FindParent<T>(parent);
            }
        }
