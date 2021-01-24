            public static void PlacementCallBack(object sender, DependencyPropertyChangedEventArgs e)
            {
                var myuserControl = sender as MyUserControl;
                myuserControl.ReferencedButton = e.NewValue as UIElement;
            }
