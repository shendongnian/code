else if(s.Contains(tbSecondClub.Text))
{
    s.Count = lblResult2.Text; //problem is here
}
S is our string that we just read from the file.
You're saying assoung S.Count (The length of the string) to text.
I don't think this is what you want. We want to return the number of times _specified_ strings show up in a _specified file_
Let's refactor this, (And add some tricks along the way).
// Let's create a dictionary to store all of our desired texts, and the counts.
var textAndCounts = new Dictionary<string, int>();
textAndCounts.Add(tbFirstClub.Text, 0); // Assuming the type of Text is string, change acccorrdingly
textAndCounts.Add(tbSecondClub.Text, 0);
//We added both out texts fields to our dictionary with a value of 0
// Read all the lines from the file.
var allLines = File.ReadAllLines(openFileName); /* using System.IO */
foreach(var line in allLines) 
{
   if(line.Contains(tbFirstClub.Text))
   {
       textAndCounts[tbFirstClub.Text] += 1; // Go to where we stored our count for our text and increment
   }
   if(line.Contains(tbSecondClub.Text))
   {
      textandCounts[tbSecondClub.Text] += 1;
   }
}
This should solve your problem, but it's still pretty brittle. Optimally, we want to design a system that works for any number of strings and counts them.
So how would I do it?
public Dictionary<string, int> GetCountsPerStringInFile(IEnumerable<string> textsToSearch, string filePath) 
{
   //Lets use Linq to create a dictionary, assuming all strings are unique.
   //This means, create a dictionary in this list, where the key is the values in the list, and the value is 0 <Text, 0>
   var textsAndCount = textsToSearch.ToDictionary(text => text, count => 0);
   var allLines = File.ReadAllLines(openFileName);
   foreach (var line in allLines)
   {
      // You didn't specify if a line could maintain multiple values, so let's handle that here.
      var keysContained = textsAndCounts.Keys.Where(c => line.Contains(c)); // take all the keys where the line has that key. 
      foreach (var key in keysContained)
      {
         textsAndCounts[key] += 1; // increment the count associated with that string.
      }
   }
   return textsAndCounts;
}
The above code allows us to return a data structure with any amount of strings with a count. 
I think this is a good example for you to save you some headaches going forward, and it's probably a good first toe-dip into design patterns. I'd suggest looking up some material on Data structures and their use cases.
  
