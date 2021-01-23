    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;
     
    if (Operators.LikeString("This is just a test", "*just*", CompareMethod.Text))
    {
      Console.WriteLine("This matched!");
    }
