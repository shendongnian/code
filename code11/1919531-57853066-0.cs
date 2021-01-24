private string[]display;
private int[]lineHashes;
public void OnUpdate()
{
   //read file
   string[] newLines = File.ReadAllLines(filePath);
   //grow array if nessesary
   if(display.Length < newLines.Length)
   {
      Array.Resize(display, newLines.Length);
   }   
   //detect changed lines
   var replaceLines = new List<string>();
   var replaceIndicies = new List<int>();
   for(var i = 0; i < newLines.Length; i++)
   {
      var lineHash = GetStringHash(line);
      if (lineHash != lineHashes[i])
      {
         replaceLines.Add(newLines[i]);
         replaceIndicies.Add(i);
      }
      lineHashes[i] = lineHash;
   }
   //replace lines display and Listbox
   for(var i = 0; i < replaceIndicies.Count; i++)
   {
      var newLine = replaceLines[i];
      display[replaceIndicies[i]] = newLine;
      ListBoxDisplay.Items[i] = newLine;
   }
}
private int GetStringHash(string str)
{
   //whatever hash alorithm you like, just copypaste one from stackoverflow.com
}
