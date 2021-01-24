    string input = "\"3040063816\",\"123456789\",\"0.00\",\"0.00\",\"-95.99\",\"10/28/19\",\"09:04:11\",\"1\"\r";
    List<string> stringArr = input.Split(',').Select(x => x.Replace(@"""", "")).ToList();
    Console.WriteLine(Convert.ToInt64(stringArr[0])); // This is a large number. Has to be int64.
    Console.WriteLine(int.Parse(stringArr[1]));
    Console.WriteLine(float.Parse(stringArr[2]));
    Console.WriteLine(float.Parse(stringArr[3]));
    Console.WriteLine(float.Parse(stringArr[4]));
    Console.WriteLine(DateTime.Parse(stringArr[5]));
    Console.WriteLine(DateTime.Parse(stringArr[6]));
    Console.WriteLine(int.Parse(stringArr[7]));
**Output**
3040063816
123456789
0
0
-95.99
10/28/2019 12:00:00 AM
12/30/2019 9:04:11 AM
1
Each of the strings inside your string has double quotes in it. To remove that and make it a number representation, remove the quotes from each of the string after splitting it.
[Review this post][1] for conversion of large numbers and which format they can be converted to.
  [1]: https://stackoverflow.com/a/9696777/1390548
