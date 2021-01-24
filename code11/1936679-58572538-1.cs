public class Grades
{
  private double[] _Items;
  public int Count
  {
    get
    {
      return _Items.Length;
    }
  }
  public Grades()
  {
  }
  public Grades(double[] grades)
  {
    _Items = grades;
  }
  public int Resize()
  {
    Console.Write("Enter number of students:");
    int.TryParse(Console.ReadLine(), out int count);
    if ( _Items == null )
      _Items = new double[count];
    else
      Array.Resize(ref _Items, count);
    return Count;
  }
  public double[] Initialize(int count)
  {
    if ( _Items == null )
      _Items = new double[count];
    else
      Array.Resize(ref _Items, count);
    for ( int i = 0; i < _Items.Length; i++ )
    {
      Console.WriteLine("Enter grade of student {0}:", i + 1);
      double.TryParse(Console.ReadLine(), out _Items[i]);
    }
    return _Items;
  }
  public void Print()
  {
    if ( _Items == null )
      Console.WriteLine("There is no students.");
    else
    {
      Console.WriteLine("Number of students are {0}", _Items.Length);
      for ( int i = 0; i < _Items.Length; i++ )
        Console.WriteLine("Grade of student {0} is {1}", i + 1, _Items[i]);
    }
  }
}
static void Test()
{
  var g = new Grades();
  g.Initialize(5);
  g.Print();
}
Result:
Enter grade of student 1:
1
Enter grade of student 2:
2
Enter grade of student 3:
3
Enter grade of student 4:
4
Enter grade of student 5:
5
Number of students are 5
Grade of student 1 is 1
Grade of student 2 is 2
Grade of student 3 is 3
Grade of student 4 is 4
Grade of student 5 is 5
You may rename `Grades` to `Students` and `_Items` to `_Grades`.
