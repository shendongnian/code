    if (scheduleListBox.Items.Count == 0)
    {
        List<ScheduleItem> scheduleItems = new List<ScheduleItem>();
        for (int i = 0; i < timeSplit.Length; i++)
        {
            string timeList = timeSplit[i];
            string titleList = titleSplit[i];
            string categoryList = categorySplit[i];
            ScheduleItem item = new ScheduleItem
                                    {
                                        Time = DateTime.Parse(timeList),
                                        Title = titleList,
                                        Category = categoryList
                                    };
            scheduleItems.Add(item);
        }
        scheduleItems.Sort();
        
        foreach (ScheduleItem item in scheduleItems)
        {
            //Define grid column, size
            Grid schedule = new Grid();
            //Column to hold the time of the schedule
            ColumnDefinition timeColumn = new ColumnDefinition();
            GridLength timeGrid = new GridLength(110);
            timeColumn.Width = timeGrid;
            schedule.ColumnDefinitions.Add(timeColumn);
            //Text block that show the time of the schedule
            TextBlock timeTxtBlock = new TextBlock();
            timeTxtBlock.Text = item.Time;
            //Set the alarm label text block properties - margin, fontsize
            timeTxtBlock.FontSize = 28;
            timeTxtBlock.Margin = new Thickness(0, 20, 0, 0);
            //Set the column that will hold the time of the schedule
            Grid.SetColumn(timeTxtBlock, 0);
            schedule.Children.Add(timeTxtBlock);
            //Column to hold the title of the schedule
            ColumnDefinition titleColumn = new ColumnDefinition();
            GridLength titleGrid = new GridLength(300);
            titleColumn.Width = titleGrid;
            schedule.ColumnDefinitions.Add(titleColumn);
            //Text block that show the title of the schedule
            TextBlock titleTxtBlock = new TextBlock();
            titleTxtBlock.Text = item.Title;
            if (item.Title.Length > 15)
            {
                string strTitle = item.Title.Substring(0, 15) + "....";
                titleTxtBlock.Text = strTitle;
            }
            else
            {
                titleTxtBlock.Text = item.Title;
            }
            //Set the alarm label text block properties - margin, fontsize
            titleTxtBlock.FontSize = 28;
            titleTxtBlock.Margin = new Thickness(20, 20, 0, 0);
            //Set the column that will hold the title of the schedule
            Grid.SetColumn(titleTxtBlock, 1);
            schedule.Children.Add(titleTxtBlock);
            //Column 3 to hold the image category of the schedule
            ColumnDefinition categoryImageColumn = new ColumnDefinition();
            GridLength catImgnGrid = new GridLength(70);
            categoryImageColumn.Width = catImgnGrid;
            schedule.ColumnDefinitions.Add(categoryImageColumn);
            //Text block that show the category of the schedule
            TextBlock categoryTxtBlock = new TextBlock();
            categoryTxtBlock.Text = item.Category;
            //set the category image and its properties - margin, width, height, name, background, font size
            Image categoryImage = new Image();
            categoryImage.Margin = new Thickness(-20, 15, 0, 0);
            categoryImage.Width = 50;
            categoryImage.Height = 50;
            if (categoryTxtBlock.Text == "Priority")
            {
                categoryImage.Source = new BitmapImage(new Uri("/AlarmClock;component/Images/exclamination_mark.png", UriKind.Relative));
            }
            else
                if (categoryTxtBlock.Text == "Favourite")
                {
                    categoryImage.Source = new BitmapImage(new Uri("/AlarmClock;component/Images/star_full.png", UriKind.Relative));
                }
            Grid.SetColumn(categoryImage, 2);
            schedule.Children.Add(categoryImage);
        }
        
    }
