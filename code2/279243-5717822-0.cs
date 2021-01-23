for (int i = 0; i &lt; s.Length; i++)
{
   if (char.IsLetterOrDigit(s, i)) // or if (!char.IsWhiteSpace(s, i))
   {
      // append to StringBuilder
   }
}
