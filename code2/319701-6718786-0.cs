    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace controlsAtRuntime
    {
        
        public class Form1 : Form
        {
            private FlowLayoutPanel mainPanel;
            private Button button1;
            private Button button2;
            private Button button3;
            
            MyDataClass1[] T1Items = new MyDataClass1[] { new MyDataClass1 { Name = "I am element 1" }, new MyDataClass1 { Name = "I am element 2" } };
            MyDataClass2[] T2Items = new MyDataClass2[] { new MyDataClass2 { Name = "Foo" }, new MyDataClass2 { Name = "Bar" } };
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void setUpControlsAtRuntime()
            {
                mainPanel.Controls.Clear();
                foreach (var item in T1Items)
                {
                    mainPanel.Controls.Add(getControlForT1Entity(item, T2Items));
                }
            }
    
            private GroupBox getControlForT1Entity(MyDataClass1 entity,IEnumerable<MyDataClass2> asscociatableData)
            {
                GroupBox box = new GroupBox();//outer element that can give our checked list box a visible name
                box.Text = entity.Name;
                box.Tag = entity; // so you can know the entity this box belongs to ...
                box.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
                box.AutoSize = true;
                CheckedListBox chklb = new CheckedListBox();
                foreach (var item in asscociatableData)
                { 
                    chklb.Items.Add(item, entity.associatedData != null && entity.associatedData.Contains(item));
                    //add all items, and check them if they were contained in entity.associatedData
                }
                box.Controls.Add(chklb);
                chklb.Location = new Point(10, 20);
                return box;
            }
    
            private IEnumerable<MyDataClass2> getCheckedItemsFromOuterBox(GroupBox box)
            { 
                var chklb = box.Controls[0] as CheckedListBox;
                if (chklb != null)
                { 
                    return chklb.CheckedItems.OfType<MyDataClass2>();
                }
                throw new Exception("whoops... that was none of the expected GroupBox Controls...");
            }
    
            private void InitializeComponent()
            {
                this.mainPanel = new System.Windows.Forms.FlowLayoutPanel();
                this.button1 = new System.Windows.Forms.Button();
                this.button2 = new System.Windows.Forms.Button();
                this.button3 = new System.Windows.Forms.Button();
                this.SuspendLayout();
                // 
                // mainPanel
                // 
                this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                            | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.mainPanel.Location = new System.Drawing.Point(12, 12);
                this.mainPanel.Name = "mainPanel";
                this.mainPanel.Size = new System.Drawing.Size(417, 269);
                this.mainPanel.TabIndex = 0;
                // 
                // button1
                // 
                this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.button1.Location = new System.Drawing.Point(330, 287);
                this.button1.Name = "button1";
                this.button1.Size = new System.Drawing.Size(99, 23);
                this.button1.TabIndex = 0;
                this.button1.Text = "save selection";
                this.button1.UseVisualStyleBackColor = true;
                this.button1.Click += new System.EventHandler(this.button1_Click);
                // 
                // button2
                // 
                this.button2.Location = new System.Drawing.Point(12, 287);
                this.button2.Name = "button2";
                this.button2.Size = new System.Drawing.Size(75, 23);
                this.button2.TabIndex = 1;
                this.button2.Text = "clear panel";
                this.button2.UseVisualStyleBackColor = true;
                this.button2.Click += new System.EventHandler(this.button2_Click);
                // 
                // button3
                // 
                this.button3.Location = new System.Drawing.Point(93, 287);
                this.button3.Name = "button3";
                this.button3.Size = new System.Drawing.Size(75, 23);
                this.button3.TabIndex = 2;
                this.button3.Text = "setup panel";
                this.button3.UseVisualStyleBackColor = true;
                this.button3.Click += new System.EventHandler(this.button3_Click);
                // 
                // Form1
                // 
                this.ClientSize = new System.Drawing.Size(441, 322);
                this.Controls.Add(this.button3);
                this.Controls.Add(this.button2);
                this.Controls.Add(this.button1);
                this.Controls.Add(this.mainPanel);
                this.Name = "Form1";
                this.ResumeLayout(false);
    
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                foreach (var item in mainPanel.Controls.OfType<GroupBox>().Where(x=>x.Tag is MyDataClass1))
                {
                    var entity = item.Tag as MyDataClass1;
                    entity.associatedData = getCheckedItemsFromOuterBox(item);
                }
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                mainPanel.Controls.Clear();
            }
    
            private void button3_Click(object sender, EventArgs e)
            {
                setUpControlsAtRuntime();
            }
        }
        public class MyDataClass1
        {
            public String Name { get; set; }
            public IEnumerable<MyDataClass2> associatedData { get; set; }
        }
        public class MyDataClass2
        {
            public String Name { get; set; }
            public override string ToString()
            {
                return Name;
            }
        }
    }
