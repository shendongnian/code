Regex r = new Regex(@",(?=[0-9]{2}\/[0-9]{2}\/[0-9]{4})");   // looks for the comma just before the date
var newStr = r.Replace(str, "\r\n");         // here 'str' is the input string which contains unformatted csv file content.
For your requirement, you need to modify the `csvedit()` as follows:
public void csvedit()
{
    string path = @"C:\Users\Sunil\Videos\original\GSK.csv";
    string csvContent = System.IO.File.ReadAllText(path);
    Regex r = new Regex(@"("",""(?=[0-9]{2}\/[0-9]{2}\/[0-9]{4}))");  // looks for the 'double quotes - comma - double quotes' pattern just before the date
    var newStr = r.Replace(csvContent, "\n").Trim("\"".ToArray());
    System.IO.File.WriteAllText(path, newStr);    //this will overwrite the text present in existing file.
}
