    public static void SwipteLeftRight(Microsoft.Phone.Controls.Pivot pivotControl, Microsoft.Phone.Controls.WebBrowser webBrowserControl)        
            {
                var gesListener = GestureService.GetGestureListener(webBrowserControl);
                gesListener.Flick += ((sen, args) =>
                {
                    if (args.Direction == System.Windows.Controls.Orientation.Horizontal)
                    {
                        if (args.HorizontalVelocity < 0)
                        {
                            
                            if (((Microsoft.Phone.Controls.PivotItem)(pivotControl.SelectedItem)).Header.ToString().Trim() == "Pivot Item name")
                            {
                                pivotControl.SelectedIndex = 2; //Next Pivot item
                            }
                        }
                        else if (args.HorizontalVelocity > 0)
                        {
                           
                            if ((Microsoft.Phone.Controls.PivotItem)(pivotControl.SelectedItem)).Header.ToString().Trim() == "Pivot Item name")
                            {
                                pivotControl.SelectedIndex = 0; // Previous Pivot Item
                            }
                        }
                    }
                });
            }
