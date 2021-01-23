        StreamReader _reader;
        public void Init()
        {
            _reader = new StreamReader("FileName.txt");
            _timer.Start();
        }
        public void timer_Tick(object sender, EventArgs e)
        {
            if (curve == null)
                return;
            IPointListEdit list = curve.Points as IPointListEdit;
            if (list == null)
                return;
            double time = (Environment.TickCount - tickStart) / 1000.0;
            try
            {
                string line = _reader.ReadLine();
                if (line == null)
                {
                    _timer.Stop();
                    return;
                }
                double value = double.Parse(line);
                list.Add(time, value);
            }
            catch (Exception err)
            {
                //Do Something
            }
        }
