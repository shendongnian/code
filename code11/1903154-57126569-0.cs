    string[] words = textBox1.Lines;
    string[] numbers = textBox2.Lines;
    var resultLines = new string[words.Length];
    for (int i = 0; i < words.Length; i++) {
        var sb = new StringBuilder();
        for (int j = 0; j < numbers.Length; j++) {
            sb.Append(words[i]).Append(numbers[j]).Append("_");
        }
        if (sb.Length > 0) {
            sb.Length--; // remove the last "_"
        }
        resultLines[i] = sb.ToString();
    }
    reultsTextBox.Lines = resultLines;
