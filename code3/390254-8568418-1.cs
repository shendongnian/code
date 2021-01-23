        private void backgroundWorker6Progress_DoWork(object sender, DoWorkEventArgs e)
        {
            bool cont = true;
            while (cont)
            {
                PauseForMilliSeconds(100);
                updateProgressbar1(false);
                if (noTasksExistCheck())
                {
                    updateProgressbar1(true);
                    cont = false;
                }
            }
        }
