    public partial class Form1 : Form
        {
            List<Control> controls;
    
            public Form1()
            {
                Label Label = new Label();
                TextBox Value = new TextBox();
                TextBox Weight = new TextBox();
                TextBox Width = new TextBox();
                TextBox Height = new TextBox();
                TextBox Length = new TextBox();
                controls.Add(Label);
                controls.Add(Value);
                controls.Add(Weight);
                controls.Add(Width);
                controls.Add(Height);
                controls.Add(Length);
            }
           /*
             here you add your code to fill table layout...
             .
             .
             .
             .
           */
           // remove button
          private void button2_Click(object sender, EventArgs e)
          {
            for (int i = 0; i < controls.Count; i++)
               {
                    tableLayoutPanel1.Controls.Remove(controls[i]);
               }
          }
       }
