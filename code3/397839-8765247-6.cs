    string[] ts = txtVnes.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
    int k = 0;
    for (int i = 0; i < ts.Length && k < 6; i++) {
        if (IsValid(ts[i])) { // Where IsValid is a method containing your validation logic.
            pole[k++].Text = ts[i];
        }
    }
    
    // Fill remaining labels
    for (int i = k; i < 6; i++) {
        pole[i].Text = "not valid";
    }
