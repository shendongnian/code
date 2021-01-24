        public static void CreateTheme(FrameworkElement TargetFrameworkElement, int ZDepth)
        {
            //MAKE SURE THAT PARENT IS TYPE OF GRID
            if (VisualTreeHelper.GetParent(TargetFrameworkElement) is Grid)
            {
                //GET PARENT GRID
                Grid ParentGrid = VisualTreeHelper.GetParent(TargetFrameworkElement) as Grid;
                //CREATE BORDER FOR SHADOW (RECIEVER). MAKE SURE THERE ARE SPACE TO SHOW SHADOW SO SET MARGIN NEGATIVE.
                Border ShadowReciever = new Border() { Margin = new Thickness(-ZDepth) };
                //ADD RECIEVER TO PARENT GRID
                ParentGrid.Children.Insert(0, ShadowReciever);
                //CREATE NEW THEME SHADOW
                ThemeShadow SharedShadow = new ThemeShadow();
                //CONNECT SHADOW TO FRAMEWORK ELEMENT
                TargetFrameworkElement.Shadow = SharedShadow;
                //CONNECT RECIEVER TO THEME SHADOW
                SharedShadow.Receivers.Add(ShadowReciever);
                //SET SHADOW DEPTH
                TargetFrameworkElement.Translation += new Vector3(0, 0, ZDepth);
            }
            else
            {
                //ERROR. PARENT MUST BE TYPE OF GRID
            }
        }
