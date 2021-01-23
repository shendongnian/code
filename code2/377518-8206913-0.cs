    using System;
    using System.Windows.Forms;
    
    public class Program
    {
      public static void Main()
      {
        var form = new Form();
        form.Text = "Cursor Positioning Test";
        form.Visible = true;
        form.Shown += delegate(object sender, EventArgs args) {
          foreach (var control in form.Controls)
          {
            var textBox = control as TextBox;
            if (textBox != null)
            {
              textBox.Focus();
              textBox.SelectionStart = 2;
              textBox.SelectionLength = 0;
            }
          }
        };
        
        var textBox1 = new TextBox();
        textBox1.Text = "hello";
        textBox1.Left = 10;
        textBox1.Top = 10;
        form.Controls.Add(textBox1);
    
        var textBox2 = new TextBox();
        textBox2.Text = "stack";
        textBox2.Left = 10;
        textBox2.Top = 10 + textBox1.Height + 10;
        form.Controls.Add(textBox2);
    
        var textBox3 = new TextBox();
        textBox3.Text = "overflow";
        textBox3.Left = 10;
        textBox3.Top = 10 + textBox1.Height + 10 + textBox2.Height + 10;
        form.Controls.Add(textBox3);
    
        Application.Run(form);
      }
    }
