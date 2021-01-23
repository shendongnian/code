    myButton1.Click += new MyButtonClick;
    myButton2.Click += new MyButtonClick;
    myButton3.Click += new MyButtonClick;
    myButton4.Click += new MyButtonClick;
    myButton5.Click += new MyButtonClick;
    myButton6.Click += new MyButtonClick;
    void MyButtonClick(object sender, EventArgs e)
    {
        Button button = sender as Button;
        //here you can check which button was clicked by the sender
    }
