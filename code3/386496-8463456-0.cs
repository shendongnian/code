    // Read the file and display it line by line in text box 
    System.IO.StreamReader file = new System.IO.StreamReader("arabic.txt", Encoding.UTF8); 
    while ((line = file.ReadLine()) != null) 
    { 
        txtfile[count] = line; 
        textBox1.Text += txtfile[count]+Environment.NewLine; 
 
        count++; 
    } 
 
    file.Close(); 
