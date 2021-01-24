c#
void Main()
{
   string text = "I want to throw my pc off the window. I want to go party";
   string word = "want";
   
    var indexes = GetWordIndexes(text,word)
	foreach (var inx in indexes)
	{
		markup(text, inx, richtextbox)
	}
}
public IEnumerable<int> GetWordIndexes(string text, string word)
{
	int wordLength = word.Length;
	for (int i = 0; i < text.Length; i++)
	{
		if (!(text.Length - wordLength < i) && text.Substring(i,wordLength) == word) 
			yield return i;
	}
}
 
