C#
private void transBtn_Click(object sender, EventArgs e)
{
    english = engTxtBx.Text;
    english = english.Trim();
    string[] columns = english.Split(' ');
    for (int i = 0; i < columns.Length; i++)
    {
        if (isVowel(columns[i][0]))
        {
            // Start with vowel.
            pigLatin = columns[i] + "way";
        }
        else
        {
            // Start with consonant. Get index of first vowel.
            int index = columns[i].IndexOfAny(vowels);
            if (index == -1)
            {
                // No vowel in columns[i].
                // You have to decide what to do.
            }
            else if (index == 1)
            {
                // First vowel is the second letter.
                pigLatin = columns[i].Substring(1) + columns[i][0] + "way";
            }
            else
            {
                // First vowel is after the second letter.
                pigLatin = columns[i].Substring(index) + columns[i].Substring(index - 1, 1) + "way";
            }
        }
        plTxtBx.Text += pigLatin;
    }
                                 
}
private static char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
private static bool isVowel(char c)
{
    return vowels.Contains(c);
}
