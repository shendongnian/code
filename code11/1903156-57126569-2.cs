    string[] words = textBox1.Lines;
    string[] numbers = textBox2.Lines;
    var resultLines = new string[words.Length];
    var sb = new StringBuilder();
    for (int i = 0; i < words.Length; i++) {
        sb.Length = 0; // Reset StringBuilder for the next line.
        for (int j = 0; j < numbers.Length; j++) {
            sb.Append(words[i]).Append(numbers[j]).Append("-");
        }
        if (sb.Length > 0) {
            sb.Length--; // remove the last "-"
        }
        resultLines[i] = sb.ToString();
    }
    resultsTextBox.Lines = resultLines;
