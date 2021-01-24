List<string> lines = myString.Split(Environment.NewLine).Where((l,index) => index % 2 != 0).ToList();
Then you can get the results as below: 
foreach (var line in lines)
{
    // Get every 3rd word in the line
    var thirdWords = line.Split(' ').Where((w,index) => index % 3 == 2).ToList();
    // Get words with 2 or more vowels in it. 
    // Have you tested words that have same vowel twice?
    var matchWords = thirdWords.Where(w => w.Intersect(vowels).Count() >= vowelCount).ToList();
    //if words with vowels found, update 'wordCount' and 'lineCount' 
    if (matchWords.Any()) {
        wordCount = wordCount + matchWords.Count;
        lineCount++;
    }
}
Console.WriteLine("WordCount : {0}, LineCount : {1}", wordCount, lineCount);
