public string Truncate(string s, int length, bool includeEllipsis = true)
{
     // Make sure you consider nulls
     if(String.IsNullOrEmpty(s))
     {
          return s;
     }
     if (s.Length > length)
     {
          // Return the substring and an optional ellipsis
          return s.Substring(0, length) + (includeEllipsis ? "..." : "");
     }
     // The string was shorter than your requested length, so return it all
     return s;
}
Usage for your example might look like this:
    label5.Text = $"Clipboard: {Truncate(richTextBox2.Text, 52)}"; 
