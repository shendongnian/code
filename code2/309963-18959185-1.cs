    var colors
      = new[] { Color.Red, Color.Black, Color.Blue, Color.Green /*...*/ };
    ILArray<float> data = ILMath.zeros<float>(
      3,
      colors.Length);
    ILArray<float> colorData = ILMath.zeros<float>(
      3,
      colors.Length);
    int index = 0;
    foreach (var p in colors)
    {
      data[0, index] = p.GetHue();
      data[1, index] = p.GetSaturation();
      data[2, index] = p.GetBrightness();
      colorData [0, index] = p.R / 255.0f;
      colorData [1, index] = p.G / 255.0f;
      colorData [2, index] = p.B / 255.0f;
      index++;
    }
    var points = new ILPoints()
    {
      Positions = data,
      Colors = colorData 
    };
    points.Color = null;
    var plot = new ILPlotCube(twoDMode: false)
    {
      Rotation = Matrix4.Rotation(new Vector3(1, 1, 0.1f), 0.4f),
      Projection = Projection.Orthographic,
      Children = { points }
    };
    plot.Axes[0].Label.Text = "Hue";
    plot.Axes[1].Label.Text = "Saturation";
    plot.Axes[2].Label.Text = "Brightness";
    this.ilPanel1.Scene = new ILScene { plot };
