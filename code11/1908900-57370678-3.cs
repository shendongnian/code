var scoreTable = new []{50, 100, 150, 250, 400, 650, 1050, 1700, 2750, 4450, 7200, 11650, 18850, 
30500, 49350, 79850, 129200, 209050, 338250, 547300, 885550, 1432850, 2318400, 3751250, 
6069650, 9820900, 15890550, 25711450, 41602000, 67313450, 108915450, 176228900, 
285144350, 461373250, 746517600, 1207890850, 1954408450};
For the math to create the table, let's be simple:
var thresholds = new List<int> {50, 100};  
var index = 1;
while(true){
  var temp = thresholds[cpt] + thresholds[cpt - 1];
  if (temp < 0) break;
  thresholds.Add(temp);
}
And to know the level:
var score = 51;
// Index is Zero-based numbering. Count is One-based. Index = Count -1;
var level = scoreTable.Where(x => x < score ).Count() - 1; 
Binary.Search:
public class SupComparer : IComparer
{
    public int Compare(object x, object y)
    {
        var t1 = UInt64.Parse(x.ToString());
        var t2 = UInt64.Parse(y.ToString());
        return  t1.CompareTo(t2) > 0 ? 1 : 0;
    }
}
var cp = new SupComparer();
var level = Array.BinarySearch(scoreTable, score, (IComparer)cp);
