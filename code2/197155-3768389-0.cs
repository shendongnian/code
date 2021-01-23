    {
        public class TestObject
        {
            public string Name { get; set; }
            public int Value { get; set; }
        }
        public partial class Form1 : Form
        {
            private System.Windows.Forms.ComboBox comboBox1;
            public Form1()
            {
                this.comboBox1 = new System.Windows.Forms.ComboBox();
                this.SuspendLayout();
                // 
                // comboBox1
                // 
                this.comboBox1.FormattingEnabled = true;
                this.comboBox1.Location = new System.Drawing.Point(23, 13);
                this.comboBox1.Name = "comboBox1";
                this.comboBox1.Size = new System.Drawing.Size(121, 21);
                this.comboBox1.TabIndex = 0;
                this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(284, 262);
                this.Controls.Add(this.comboBox1);
                this.Name = "Form1";
                this.Text = "Form1";
                this.ResumeLayout(false);
                BindingList<TestObject> objects = new BindingList<TestObject>();
                for (int i = 0; i < 10; i++)
                {
                    objects.Add(new TestObject() { Name = "Object " + i.ToString(), Value = i });
                }
                comboBox1.ValueMember = null;
                comboBox1.DisplayMember = "Name";
                comboBox1.DataSource = objects;
            }
            private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
            {
                if (comboBox1.SelectedValue != null)
                {
                    TestObject current = (TestObject)comboBox1.SelectedValue;
                    MessageBox.Show(current.Value.ToString());
                }
            }
        }
    }
