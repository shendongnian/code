    bool btn1,btn2,btn3;
        
    private void button1_Click(object sender, EventArgs e)
    {
         AvtivateButtons(1,btn1);
    }
    private void ActivateButtons(int btn, bool btnState)
    {
                
                switch (btn)
                {
                    case 1:
                        button1.Click -= button1_Click;
                        btnEstate = false;
                        break;
                    case 2:
                        button2.Click -= button2_Click;
                        btnEstate = false;
                        break;
                    case 3:
                        button3.Click -= button3_Click;
                        btnEstate = false;
                        break;
                }
    
                if (!btn1)
                {
                    button1.Click += button1_Click;
                }
                if (!btn2)
                {
                    button2.Click += button2_Click;
                }
                if (!btn3)
                {
                    button3.Click += button3_Click;
                }
    
    
                btnState = true;
    
    }
