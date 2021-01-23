    for (int i = 0; i < 25; i++)
    {
        ...
        pbList.Add(new PictureBox());
    
        var index = i;
        pbList[i].MouseHover += 
            delegate
            {
                lb_beeInfo.Text = "You are hovering over: "+beeList[index].name;
            };
    }
