string path = @"C:\\important.txt";
if (File.Exists(path))
     File.AppendAllText(path,"\r\n" + name + "," + socialid + "," + town + "," + numsold);
else
     File.AppendAllText(path, name + "," + socialid + "," + town + "," + numsold);
string[] lines = File.ReadAllLines(path);
foreach(var line in lines)
{
    string[] array = line.Split(',');
    int num1 = Int32.Parse(array[3]);
    if(num1 < 50)
    {
        str2 = line.Replace(",", " ");
        System.Console.WriteLine(str2);
        counter++;
    }
}
