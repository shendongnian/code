     var borderSize = new Size(
        (SystemInformation.FrameBorderSize.Width * SystemInformation.BorderMultiplierFactor 
            + (SystemInformation.Border3DSize.Width * 2)) * 2, 
        (SystemInformation.FrameBorderSize.Height * SystemInformation.BorderMultiplierFactor 
            + (SystemInformation.Border3DSize.Height * 2)) * 2);
    var captionSize = new Size(0, SystemInformation.CaptionHeight);
    this.MinimumSize = MinimumClientSize + borderSize + captionSize;
