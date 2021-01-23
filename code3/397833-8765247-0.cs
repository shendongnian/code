    var pole = new Label[42];
    string[] ts = txt.Text.Split(';');
    int k = 0;
    for (int i = 0; i < ts.Length && k < 6; i++) {
        if (IsValid(ts[i])) { // Where IsValid is a method containing your validation logic.
            pole[k++] = new Label { Text = ts[i] };
        }
    }
    
    // Fill remaining labels
    for (int i = k; i < 6; i++) {
        pole[i] = new Label { Text = "missing" };
    }
