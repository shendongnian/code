    private void getAtr_Click(object sender, EventArgs e)
    {
        for (int i = 1; i <= 10; i++)
        {
            while (vn100.CurrentAttitude == null)
            {
                Thread.Sleep(10); // < - UI can't respond in a sleep
                Application.DoEvents();
            }
            Get_Attitude();
        }
    }
