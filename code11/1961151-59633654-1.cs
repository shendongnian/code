using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Test
{
   public class Foo
   {
      public Foo()
      {
         Items = new BindingList<string>();
      }
      public IList<string> Items { get; private set; }
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
         var btn2 = new Button()
         {
            Text = "Change Object's Values",
            Dock = DockStyle.Bottom
         };
         btn2.Click += btn2_Click;
         frm.Controls.Add(btn2);
         Application.Run(frm);
      }
      static void btn_Click(object sender, EventArgs e)
      {
         MessageBox.Show(string.Join(Environment.NewLine, _dataSource.Items.ToArray()));
      }
      static void btn2_Click(object sender, EventArgs e)
      {
         var rng = new Random();
         for (int i = 0; i < _dataSource.Items.Count; i++)
         {
            var b = new byte[8];
            rng.NextBytes(b);
            _dataSource.Items[i] = Convert.ToBase64String(b);
         }
      }
      static Foo _dataSource = new Foo();
   }
}
