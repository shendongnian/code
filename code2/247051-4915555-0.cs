    new System.Threading.Timer((state) =>
    {
        length = Player.GetLength();
        pos = Player.GetCurrentPosition();
        trackBar1.Invoke(new Action(()=>trackBar1.Value = (pos / length) * 100));
    }, null, 0, 100);   
