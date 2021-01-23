    string[] ts = txtVnes.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
    for (int i = 0; i < ts.Length && i < 6; i++) {
        if (IsValid(ts[i])) { // Where IsValid is a method containing your validation logic.
            pole[i].Text = ts[i];
        } else {
            pole[i].Text = "not valid";
        }
    }
