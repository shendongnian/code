    public abstract class Base
        {
            public int Property1 { get; set; } = 20;
    
            public virtual void Display()
            {
    
                MessageBox.Show(Property1.ToString());
            }
        }
    public class Derived : Base
        {
            public int Property2 { get; set; } = 9;
            public override void Display() //without this you can't achieve what you want
            {
                base.Display();
                MessageBox.Show(Property2.ToString());
    
            }
    
        }
    public class Test
        {
            public void ShowResult()
            {
                Derived derived = new Derived();
                derived.Display();
            }
        }
    Test test = new Test();
    {
      test.ShowResult();
    }
