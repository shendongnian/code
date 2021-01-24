    private void Button_Click(object sender, RoutedEventArgs e)
            {
    
                int f = 0, t = 0;
    
                if (Int32.TryParse(box1.Text, out f))
                {
                   // successfully parsed 
                }
    
                if (Int32.TryParse(box3.Text, out t))
                {
                    // successfully parsed 
                    
                }
    
                // or just use parse..
                int f1 = Int32.Parse(box1.Text);
                int t1 = Int32.Parse(box3.Text);
    
    
                if (rangeCheck(f, t))
                {
                    Debug.WriteLine("Both are within 0 and 100");
                }
            }
    
            bool rangeCheck(int first, int third)
            {
                return (first >= 0 && first <= 100 && third >= 0 && third <= 100);
            }
