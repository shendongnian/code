private void form_load()
{
   test = new Test();
   var src = new BindingSource(test, "toto");
   src.Position = 0;
   textBox1.DataBindings.Add("Text", src, "");
}
If you were trying to dynamically create a `TextBox` for each item in an collection whose length you don't know ahead of time, it might look something like this...
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Test
{
   public class Foo
   {
      public Foo()
      {
         Items = new List<string>();
      }
      public ICollection<string> Items { get; set; }
   }
   public class BindingString
   {
      public string Value { get; set; }
   }
   static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         _dataSource.Items.Add("Value");
         _dataSource.Items.Add("Value 2");
         _dataSource.Items.Add("Value 3");
         var frm = new Form();
         var flp = new FlowLayoutPanel
         {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown
         };
         for (int i = 0; i < _dataSource.Items.Count; i++)
         {
            var bs = new BindingSource(_dataSource, "Items");
            bs.Position = i;
            var tb = new TextBox();
            tb.DataBindings.Add("Text", bs, "");
            flp.Controls.Add(tb);
         }
         frm.Controls.Add(flp);
         var btn = new Button()
         {
            Text = "Show Object's Values",
            Dock = DockStyle.Bottom
         };
         btn.Click += btn_Click;
         frm.Controls.Add(btn);
         Application.Run(frm);
      }
      static void btn_Click(object sender, EventArgs e)
      {
         MessageBox.Show(string.Join(Environment.NewLine, _dataSource.Items.ToArray()));
      }
      static Foo _dataSource = new Foo();
   }
}
