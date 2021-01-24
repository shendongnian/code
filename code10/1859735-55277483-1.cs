    public class anotherClass   
    {
      public void AddButton(Form form)
      {
        Button b = new Button() { Text = "Dynamic Button", Width = 200 };
        form.Controls.Add(b);
      }
    }
    public class MyForm
    {
     anotherClass obj = new anotherClass();
     obj.AddButton(this);
    }
