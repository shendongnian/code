    double i = 0;  
    string s = txtFeetInput.Text;
    bool result = double.TryParse(s, out i);
    if(result && i >= 0){
        textBox1.Background = Brushes.White;
    }else{
        textBox1.Background = Brushes.Red;
    }
