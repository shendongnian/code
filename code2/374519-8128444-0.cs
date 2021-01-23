    private bool positiveOnly;
    private int _myNum;
    public int MyNum
    { 
       get {return _myNum;}
       set
       {
          // use old if positive only and value less than 0
          _myNum = (positiveOnly && value < 0) ? _myNum : value;
       }
    }
    public void MyMethod()
    {
       positiveOnly = true;
       MyNum = Convert.ToInt32(txtMyTextBox.Text);
    }
