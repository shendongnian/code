    System.Collections.ArrayList al = new System.Collections.ArrayList();
    al.Add(5);
    al.Add(3);
    al.Add(1);
    al.Add(4);
    al.Add(0);
    al.Sort();
    foreach (var x in al)
    {
        Console.WriteLine(x.ToString());
    }
    al.Sort(new DescendingIntSorter());
    foreach (var x in al)
    {
        Console.WriteLine(x.ToString());
    }
    public class DescendingIntSorter : System.Collections.IComparer
    {
        public int Compare(object x, object y)
        {
            return ((int)y).CompareTo((int)x);
        }
    }
