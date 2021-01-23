    private void showPopup()
        {
            Session session = App.getSession();
            Template template = session.getTemplate();
            
            border.BorderBrush = new SolidColorBrush(Colors.White);
            border.BorderThickness = new Thickness(2);
            border.Margin = new Thickness(10, 10, 10, 10);
            int initialMargin ;
            int landMargin ; // margin for information if displayed in landscape orientation
            StackPanel stkPnlOuter = new StackPanel();
            stkPnlOuter.Background = new SolidColorBrush(Colors.Black);
            stkPnlOuter.Orientation = System.Windows.Controls.Orientation.Vertical;
            stkPnlOuter.Tap += new EventHandler<System.Windows.Input.GestureEventArgs>(stkPnlOuter_Tap);
            if (this.Orientation == PageOrientation.PortraitUp || this.Orientation == PageOrientation.PortraitDown)
            {
                initialMargin = 0;
                landMargin = 0;
            }
            else
            {
                initialMargin = 5;
                landMargin = 10;
            }
            
            TextBlock txt_blk1 = new TextBlock();
            txt_blk1.Text = "Loaded Type:";
            txt_blk1.TextAlignment = TextAlignment.Left;
            txt_blk1.FontSize = 20;
            txt_blk1.FontWeight = FontWeights.Bold;
            txt_blk1.Margin = new Thickness(5, 5, 5, 5);
            txt_blk1.Foreground = new SolidColorBrush(Colors.White);
            TextBlock txt_blk2 = new TextBlock();
            txt_blk2.Text = template.templateType == TemplateType.TYPE.TEMPLATE_FILE ? "Valido Template File" : "Valido Assessment File";
            txt_blk2.TextAlignment = TextAlignment.Left;
            txt_blk2.FontSize = 20;
            txt_blk2.Margin = new Thickness(5,initialMargin, 5, initialMargin);
            txt_blk2.Foreground = new SolidColorBrush(Colors.White);
            TextBlock txt_blk3 = new TextBlock();
            txt_blk3.Text = "Template Type:";
            txt_blk3.TextAlignment = TextAlignment.Left;
            txt_blk3.FontSize = 20;
            txt_blk3.FontWeight = FontWeights.Bold;
            txt_blk3.Margin = new Thickness(5, 10, 5, 5);
            txt_blk3.Foreground = new SolidColorBrush(Colors.White);
            TextBlock txt_blk4 = new TextBlock();
            txt_blk4.Text = TemplateClassification.getName();
            txt_blk4.TextAlignment = TextAlignment.Left;
            txt_blk4.FontSize = 20;
            txt_blk4.Margin = new Thickness(5, landMargin, 5, initialMargin);
            txt_blk4.Foreground = new SolidColorBrush(Colors.White);
            TextBlock txt_blk5 = new TextBlock();
            txt_blk5.Text = "Client Reference:";
            txt_blk5.TextAlignment = TextAlignment.Left;
            txt_blk5.FontWeight = FontWeights.Bold;
            txt_blk5.FontSize = 20;
            txt_blk5.Margin = new Thickness(5, 10, 5, 5);
            txt_blk5.Foreground = new SolidColorBrush(Colors.White);
            TextBlock txt_blk6 = new TextBlock();
            txt_blk6.Text = template.ClientRef == null ? "-" : template.ClientRef;
            txt_blk6.TextAlignment = TextAlignment.Left;
            txt_blk6.FontSize = 20;
            txt_blk6.Margin = new Thickness(5, landMargin, 5, initialMargin);
            txt_blk6.Foreground = new SolidColorBrush(Colors.White);
            TextBlock txt_blk7 = new TextBlock();
            txt_blk7.Text = "Template Code:";
            txt_blk7.TextAlignment = TextAlignment.Left;
            txt_blk7.FontWeight = FontWeights.Bold;
            txt_blk7.FontSize = 20;
            txt_blk7.Margin = new Thickness(5, 10, 5, 5);
            txt_blk7.Foreground = new SolidColorBrush(Colors.White);
            TextBlock txt_blk8 = new TextBlock();
            txt_blk8.Text = template.Code;
            txt_blk8.TextAlignment = TextAlignment.Left;
            txt_blk8.FontSize = 20;
            txt_blk8.Margin = new Thickness(5, landMargin, 5, initialMargin);
            txt_blk8.Foreground = new SolidColorBrush(Colors.White);
            TextBlock txt_blk9 = new TextBlock();
            txt_blk9.Text = "Template Title:";
            txt_blk9.TextAlignment = TextAlignment.Left;
            txt_blk9.FontWeight = FontWeights.Bold;
            txt_blk9.FontSize = 20;
            txt_blk9.Margin = new Thickness(5, 10, 5, 5);
            txt_blk9.Foreground = new SolidColorBrush(Colors.White);
            TextBlock txt_blk10 = new TextBlock();
            txt_blk10.Text = template.Title;
            txt_blk10.TextAlignment = TextAlignment.Left;
            txt_blk10.FontSize = 20;
            txt_blk10.Margin = new Thickness(5, landMargin, 5, initialMargin);
            txt_blk10.Foreground = new SolidColorBrush(Colors.White);
            TextBlock txt_blk11 = new TextBlock();
            txt_blk11.Text = "Modified Date:";
            txt_blk11.TextAlignment = TextAlignment.Left;
            txt_blk11.FontWeight = FontWeights.Bold;
            txt_blk11.FontSize = 20;
            txt_blk11.Margin = new Thickness(5, 10, 5, 5);
            txt_blk11.Foreground = new SolidColorBrush(Colors.White);
            TextBlock txt_blk12 = new TextBlock();
            txt_blk12.Text = Valido_CA.modCommon.DateFromString(template.ModifiedDate);
            txt_blk12.TextAlignment = TextAlignment.Left;
            txt_blk12.FontSize = 20;
            txt_blk12.Margin = new Thickness(5, landMargin, 5, 5);
            txt_blk12.Foreground = new SolidColorBrush(Colors.White);
            if (this.Orientation == PageOrientation.PortraitUp || this.Orientation == PageOrientation.PortraitDown)
            {
                
                stkPnlOuter.Children.Add(txt_blk1);
                stkPnlOuter.Children.Add(txt_blk2);
                stkPnlOuter.Children.Add(txt_blk3);
                stkPnlOuter.Children.Add(txt_blk4);
                stkPnlOuter.Children.Add(txt_blk5);
                stkPnlOuter.Children.Add(txt_blk6);
                stkPnlOuter.Children.Add(txt_blk7);
                stkPnlOuter.Children.Add(txt_blk8);
                stkPnlOuter.Children.Add(txt_blk9);
                stkPnlOuter.Children.Add(txt_blk10);
                stkPnlOuter.Children.Add(txt_blk11);
                stkPnlOuter.Children.Add(txt_blk12);
            }
            else
            {
                StackPanel stkPnlLeft = new StackPanel();
                stkPnlLeft.Orientation = System.Windows.Controls.Orientation.Vertical;
                stkPnlLeft.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                StackPanel stkPnlRight = new StackPanel();
                stkPnlRight.Orientation = System.Windows.Controls.Orientation.Vertical;
                stkPnlRight.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                stkPnlOuter.Orientation = System.Windows.Controls.Orientation.Horizontal;
                stkPnlLeft.Children.Add(txt_blk1);
                stkPnlRight.Children.Add(txt_blk2);
                stkPnlLeft.Children.Add(txt_blk3);
                stkPnlRight.Children.Add(txt_blk4);
                stkPnlLeft.Children.Add(txt_blk5);
                stkPnlRight.Children.Add(txt_blk6);
                stkPnlLeft.Children.Add(txt_blk7);
                stkPnlRight.Children.Add(txt_blk8);
                stkPnlLeft.Children.Add(txt_blk9);
                stkPnlRight.Children.Add(txt_blk10);
                stkPnlLeft.Children.Add(txt_blk11);
                stkPnlRight.Children.Add(txt_blk12);
                stkPnlOuter.Children.Add(stkPnlLeft);
                stkPnlOuter.Children.Add(stkPnlRight);
            }
            
            StackPanel stkPnlInner = new StackPanel();
            stkPnlInner.Orientation = System.Windows.Controls.Orientation.Horizontal;
            stkPnlInner.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            
            Button btn_OK = new Button();
            btn_OK.Content = "OK";
            btn_OK.Width = 100;
            btn_OK.Click += new RoutedEventHandler(btn_OK_Click);
            
            
            stkPnlInner.Children.Add(btn_OK);
            stkPnlInner.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            stkPnlOuter.Children.Add(stkPnlInner);
            border.Child = stkPnlOuter;
            if (this.Orientation == PageOrientation.PortraitUp || this.Orientation == PageOrientation.PortraitDown)
            {
                border.Width = 350;
                border.Height = 500;
                transforBorder(border);
                infoPopup.Child = border;
                infoPopup.IsOpen = true;
                infoPopup.VerticalOffset = (this.ActualHeight - border.Height) / 2;
                infoPopup.HorizontalOffset = (this.ActualWidth - border.Width) / 2;
            }
            else
            {
                border.Width = 600;
                border.Height = 350;
                transforBorder(border);
                infoPopup.Child = border;
                infoPopup.IsOpen = true;
                infoPopup.HorizontalOffset = (this.ActualHeight - border.Width) / 2;
                infoPopup.VerticalOffset = (this.ActualWidth - border.Height) / 2;
            }
            
            
        }
