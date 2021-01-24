    private readonly QueueModel model = new QueueModel(2);
    private readonly Control[] ovalShapes = new [] {ovalshape1, ovalshape1};
    private void timer1_Tick(object sender, EventArgs e)
    {
        model.Update(GetHeadLightStatus()); // true, false, random, you choose
        var i = 0;
        foreach (var status in model)
        {
          ovalShapes[i].IsVisible = status;
          i++;
        }
    }
