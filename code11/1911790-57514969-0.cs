C#
if (text.Contains(userInput))
{
   newText = String.join(" ", text.Split(userInput));
} else ...
But I like the way you do it as well. To fix the double spaces you can always replace double spaces with a single space.
C#
newText = newText.Replace("  ", " ");
