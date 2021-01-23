    string one = txt1.Text;  
    string two = txt2.Text;
    string result = (string.IsNullOrEmpty(one) || string.IsNullOrEmpty(two))
                     ?string.Empty
                     :double.Parse(one) + double.Parse(two);
