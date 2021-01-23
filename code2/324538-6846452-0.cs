    //Define grid column, size
    
    Grid schedule = new Grid();
    
    int i = 0;
    
    foreach (var time in timeSplit)
    {
    	timeList = time;
    	//Column 1 to hold the time of the schedule
    	ColumnDefinition scheduleTimeColumn = new ColumnDefinition();
    	GridLength timeGrid = new GridLength(110);
    	scheduleTimeColumn.Width = timeGrid;
    	schedule.ColumnDefinitions.Add(scheduleTimeColumn);
    	
    	RowDefinition rowDef = new RowDefinition();
    	schedule.RowDefinitions.Add(rowDef);
    
    	//Text block that show the time of the schedule
    	TextBlock timeTxtBlock = new TextBlock();
    	timeTxtBlock.Text = time;
    	//Set the alarm label text block properties - margin, fontsize
    	timeTxtBlock.FontSize = 28;
    	timeTxtBlock.Margin = new Thickness(0, 20, 0, 0);
    	//Set the column that will hold the time of the schedule
    	Grid.SetColumn(timeTxtBlock, 0);
    	Grid.SetRow(timeTxtBlock, i);
    
    	schedule.Children.Add(timeTxtBlock);
    	
    	i++;
    }
    
    i=0;
    
    foreach (var title in titleSplit)
    {
    	titleList = title;
    
    	//Column 2 to hold the title of the schedule
    	ColumnDefinition scheduleTitleColumn = new ColumnDefinition();
    	GridLength titleGrid = new GridLength(500);
    	scheduleTitleColumn.Width = titleGrid;
    	schedule.ColumnDefinitions.Add(scheduleTitleColumn);
    
    	//Text block that show the title of the schedule
    	TextBlock titleTxtBlock = new TextBlock();
    
    	if (title.Length > 10)
    	{
    		string strTitle = title.Substring(0, 10) + "....";
    		titleTxtBlock.Text = strTitle;
    	}
    	else
    	{
    		titleTxtBlock.Text = title;
    	}
    
    	//Set the alarm label text block properties - margin, fontsize
    	titleTxtBlock.FontSize = 28;
    	titleTxtBlock.Margin = new Thickness(60, 20, 0, 0);
    	//Set the column that will hold the title of the schedule
    	Grid.SetColumn(titleTxtBlock, 1);
    	Grid.SetRow(timeTxtBlock, i);
    
    	schedule.Children.Add(titleTxtBlock);
    	//scheduleListBox.Items.Add(schedule);
    	
    	i++;
    }
    
    i=0;
    
    foreach (var category in categorySplit)
    {
    	categoryList = category;
    
    	//Column 3 to hold the image category of the schedule
    	ColumnDefinition categoryImageColumn = new ColumnDefinition();
    	GridLength catImgnGrid = new GridLength(70);
    	categoryImageColumn.Width = catImgnGrid;
    	schedule.ColumnDefinitions.Add(categoryImageColumn);
    
    	TextBlock categoryTxtBlock = new TextBlock();
    	categoryTxtBlock.Text = category;
    
    	//set the category image and its properties - margin, width, height, name, background, font size
    	Image categoryImage = new Image();
    	categoryImage.Margin = new Thickness(-50, 15, 0, 0);
    	categoryImage.Width = 50;
    	categoryImage.Height = 50;
    	if (category == "Priority")
    	{
    		categoryImage.Source = new BitmapImage(new Uri("/AlarmClock;component/Images/exclamination_mark.png", UriKind.Relative));
    	}
    	else
    		if (category == "Favourite")
    		{
    			categoryImage.Source = new BitmapImage(new Uri("/AlarmClock;component/Images/star_full.png", UriKind.Relative));
    		}
    
    
    	Grid.SetColumn(categoryImage, 2);
    	Grid.SetRow(timeTxtBlock, i);
    	
    	schedule.Children.Add(categoryImage);
    	
    	i++;
    }
    
    scheduleListBox.Items.Add(schedule);
