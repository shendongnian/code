            BUtton_1.PointerPressed += delegate(object sender, PointerRoutedEventArgs args) 
            {
                Pointer ptr = args.Pointer;
                if (ptr.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse) // Wheel click has just on mouse
                {
                    Windows.UI.Input.PointerPoint ptrPt = args.GetCurrentPoint((Button)sender);
                    if (ptrPt.Properties.IsMiddleButtonPressed)
                    {
                        TextBox_1.Text += "Hi";
                    }
                }
                args.Handled = true;
            };
