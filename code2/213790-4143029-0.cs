    public class MyClass
    {
      public int A { get; set; }
      public string B { get; set; }
    }
    private void button1_Click(object sender, EventArgs e)
    {
      MyClass orig = new MyClass() { A = 1, B = "hello" };
      MyClass copy = new MyClass();
      PropertyInfo[] infos = typeof(MyClass).GetProperties();
      foreach (PropertyInfo info in infos)
      {
        info.SetValue(copy, info.GetValue(orig, null), null);
      }
      Console.WriteLine(copy.A + ", " + copy.B);
    }
