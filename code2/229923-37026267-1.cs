    bool _ran = false; //initial setting at start up
        private void timer_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Hour == 7 && _ran==false)
            {
                _ran = true;
                Do_Something();               
            }
            if(DateTime.Now.Hour != 7 && _ran == true)
            {
                _ran = false;
            }
        }
