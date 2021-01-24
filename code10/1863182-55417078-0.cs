    `string inputOk = "Thisisatest";
    string inputNok1 = "ThisisaTest";
    string inputNok2 = "thisisatest";
    bool resultOk = Regex.IsMatch(inputOk, "^[A-Z]{1}[a-z]+$");
    bool resultNok1 = Regex.IsMatch(inputNok1, "^[A-Z]{1}[a-z]+$");
    bool resultNok2 = Regex.IsMatch(inputNok2, "^[A-Z]{1}[a-z]+$");`
