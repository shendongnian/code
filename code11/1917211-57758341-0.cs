    string input = "xgdgyd";
    char[] charArr = input.ToCharArray();
    Array.Sort(charArr); // Sort before counting as Gian Paolo suggests!
    int count;
    string output = "";
    for (int i = 0; i < charArr.Length; i += count) { // We can increment by count!
        count = 1;
        // Note that we can combine the conditions within the for-statement
        for (int j = i + 1; j < charArr.Length && charArr[j] == charArr[i]; j++) {
            count++;
        }
        output += charArr[i] + count.ToString();
    }
    Console.WriteLine(output); // ==> d2g2x1y1
