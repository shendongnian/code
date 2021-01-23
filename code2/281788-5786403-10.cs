    public void shows()
    {
        ...
        while (Reader.Read())
        {
            while (true) 
            {
                lock (lockObject) 
                {
                    if (!isPaused)
                        break;
                }
                Thread.Sleep(1000);
            }
            k = (string)(Reader.GetValue(1));
            pictureBox1.Image = Image.FromFile(k);
            Thread.Sleep(3000);
        }
        ...
    }
