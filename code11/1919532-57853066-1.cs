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
In regards to your comment I assume that the code runs in a seperate thread from the UI, you need to consider the following code. In regards to how to launch a seperate thread you base the code I wrote in a class based on Thread and then simply start it in from your main thread, you would then need to implement a System.Timers.Timer that checks the update function regularly, or implement a FileWatcher.
YourWindow _yourWindow;
Constructor(Window yourWindow)
{
   _yourWindow = (YourWindow)GetWindow(yourWindow);
}
if youre on WPF you might need to use:
YourWindow.Dispatcher.Invoke(delegate => 
{
   _yourWindow.ListBoxDisplay.Items[i] = newLine;
}
