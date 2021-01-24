    public void Read()
    {
        System.Threading.Tasks.Task.Run(() =>
        {
            MediaPlayer player = new MediaPlayer();
            try
            {           
                    player.Prepared += (sender, e) =>
                    {
                        player.Start();
                    };
                    player.SetDataSource(new StreamMediaDataSource(mmInStream));
                    player.Prepare();                   
            }
            catch (IOException ex)
            {
                System.Diagnostics.Debug.WriteLine("Input stream was disconnected", ex);
            }
        }).ConfigureAwait(false);
    }
