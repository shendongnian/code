c#
using (StreamReader sr = File.OpenText(filepath))
{
     List<string>lines;
     while ((string line = sr.ReadLine()) != null)
     {    
          lines.Add(line);      
          lineCount++;
if(lineCount%2000==0)
{ 
Execute Delete Here
lines.Clear(); //dont forget.
}
     }
Execute rest of lines delete//
}
for second option I can offer BATCH delete on SQL:
https://stackoverflow.com/questions/24785439/deleting-1-millions-rows-in-sql-server
