    bool hasADigit = false;
    for (int i = 0; i < txt_Pass.Text.Length; i++) {
        for (int j = 0; j < numCheck.Length; j++) {
            if (txt_Pass.Text[i] != numCheck[j]) {
                hasADigit = true;
            }
        }
    }
    // hasADigit is true if it, well, has a digit :-)
