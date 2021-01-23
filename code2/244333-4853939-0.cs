    for (int i = 0; i < 25; i++)
    {
        ....
        pbList.Add(new PictureBox() { Tag = beeList[i] });
        pbList[i].MouseHover += new System.EventHandler(this.beeHideInfo);
    }
