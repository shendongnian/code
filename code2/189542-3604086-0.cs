    int num1 = 0;
    
    if(!String.IsNullEmpty(num1.Text) && (new Regex("^/d$").Match(num1.Text)))
    {
         num1 = Int32.Parse(num1.Text);
    }
 
