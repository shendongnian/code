    string[] ts = txtVnes.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
    for (int i = 0; i < 6; i++) {
        if (i < ts.Length && IsValid(ts[i])) { // Where IsValid is a method containing your validation logic.
            pole[i].Text = ts[i];
        } else {
            pole[i].Text = "not valid";
        }
    }
