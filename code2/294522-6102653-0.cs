        private void slideToDestination(Control destination, Control control, int delay, Action onFinish)
        {
            new Task(() =>
            {
                int directionX = destination.Left > control.Left ? 1 : -1;
                int directionY = destination.Bottom > control.Top ? 1 : -1;
                while (control.Left != destination.Left || control.Top != destination.Bottom)
                {
                    try
                    {
                        if (control.Left != destination.Left)
                        {
                            this.Invoke((Action)delegate()
                            {
                                control.Left += directionX;
                            });
                        }
                        if (control.Top != destination.Bottom)
                        {
                            this.Invoke((Action)delegate()
                            {
                                control.Top += directionY;
                            });
                        }
                        Thread.Sleep(delay);
                    }
                    catch
                    {
                        // objects can be disposed on another thread
                        break;
                    }
                }
                if (onFinish != null) onFinish();
            }).Start();
        }
