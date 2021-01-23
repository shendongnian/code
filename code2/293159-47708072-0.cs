    var xpage = your user control or page to which scroll bar need to be added at runtime
                
                xpage.SetValue(ScrollViewer.CanContentScrollProperty, true);
                xpage.SetValue(ScrollViewer.HorizontalScrollBarVisibilityProperty, ScrollBarVisibility.Auto);
                xpage.SetValue(ScrollViewer.VerticalScrollBarVisibilityProperty, ScrollBarVisibility.Auto);
                var scrollViewer = xpage.Content as ScrollViewer;
                if (scrollViewer != null)
                {
                    var content = scrollViewer.Content;
                    scrollViewer.Content = null;
                    xpage.Content = content;
                }
                else
                {
                    var content = xpage.Content;
                    xpage.Content = null;
                    xpage.Content = new ScrollViewer { Content = content };
                }
