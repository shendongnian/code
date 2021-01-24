foreach (char character in str) // takes each character from the line
{
    if (alphabet.ToCharArray().Contains(character))
    {
        encoded += strROT13[Array.IndexOf(alphabet.ToCharArray(), character)];
    }
    else
    {
        encoded += character;
    }
}
