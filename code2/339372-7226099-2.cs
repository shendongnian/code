    if (pictureBox == null || !pictureBox.IsHandleCreated) {
        continue;
    }
    
    Action setTooltipAndImage = () => {
        var toolTip = new ToolTip();
        GameServer tempGameFile = gameServer;
        toolTip.SetToolTip(pictureBox, string.Format(...));
        pictureBox.Image = Resources.RedButton;
    };
        
    if (pictureBox.InvokeRequired) {                        
        pictureBox.Invoke(setTooltipAndImage);
    } else {
        setTooltipAndImage();
    }
