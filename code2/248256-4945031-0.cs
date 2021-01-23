        static void ThreadFunc()
        {
            _splash = new Splash();
            _splash.Show();
            while (!_shouldClose)
            {
                Application.DoEvents();
                Thread.Sleep(100);
                if (new Random().Next(1000) < 10)
                {
                    _splash.Invoke(new MethodInvoker(_splash.RandomizeText));
                }
            }
            for (int n = 0; n < 18; n++)
            {
                Application.DoEvents();
                Thread.Sleep(60);
            }
            if (_splash != null)
            {
                _splash.Close();
                _splash = null;
            }
        }
