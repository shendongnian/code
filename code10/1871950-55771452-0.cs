    case 15: // Views\PageExample.xaml line 72
        this.obj15 = (global::Windows.UI.Xaml.Controls.ToggleMenuFlyoutItem)target;
        this.obj15Click = (global::System.Object p0, global::Windows.UI.Xaml.RoutedEventArgs p1) =>
        {
            //Warning CS4014 because of line below. 
            //I can add await before this line all I want, 
            //but the file gets regenerated anyway.
            this.dataRoot.ViewModel.Refresh();
        };
        ((global::Windows.UI.Xaml.Controls.ToggleMenuFlyoutItem)target).Click += obj15Click;
        this.bindingsTracking.RegisterTwoWayListener_15(this.obj15);
        break;
