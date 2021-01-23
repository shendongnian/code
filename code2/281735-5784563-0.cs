    var sbOut = new StringBuilder();
    string myString = "ABCXYZ";
    foreach (char c in myString) {
        sbOut.Append(c);
        if (c == 'X') {
            sbOut.Append(c);
        }
    }
    Console.WriteLine(sbOut.ToString());
