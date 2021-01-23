    bool _ran = false;
        private void tmrProcessSMS_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Hour == 7 && _ran==false)
            {
                _ran = true;
                Do_Something();               
            }
            if(DateTime.Now.Hour != 7 )
            {
                _ran = false;
            }
        }
