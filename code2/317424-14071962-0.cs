    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace INQ_adm.Forms.ControlsX
    {
        public class TextBoxX : TextBox
        {
            private static int UNDO_LIMIT = 0;
            private List<Item> LastData = new List<Item>();
            private int undoCount = 0;
            private Boolean undo = false;
            public TextBoxX()
            {
                InitializeComponent();
            }
           protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
            {
                if (keyData == (Keys.Control | Keys.Z))
                {
                    undo = true;
                    try
                    {
                        ++undoCount;
                        this.Text = LastData[LastData.Count - undoCount - 1].text;
                        this.SelectionStart = LastData[LastData.Count - undoCount - 1].position;
                        this.PerformLayout();
                    }
                    catch
                    {
                        --undoCount;
                    }
                    undo = false;
                    return true;
                }
                if (keyData == (Keys.Control | Keys.Y))
                {
                    undo = true;
                    try
                    {
                        --undoCount;
                        this.Text = LastData[LastData.Count - undoCount + 1].text;
                        this.SelectionStart = LastData[LastData.Count - undoCount + 1].position;
                        this.PerformLayout();
                    }
                    catch
                    {
                        ++undoCount;
                    }
                    undo = false;
                    return true;
                }
                return base.ProcessCmdKey(ref msg, keyData);
            }
            private void textBoxX_TextChanged(object sender, EventArgs e)
            {
                if (!undo)
                {
                    LastData.RemoveRange(LastData.Count - undoCount, undoCount);
                    LastData.Add(new Item(this.Text, this.SelectionStart));
                    undoCount = 0;
                        if (UNDO_LIMIT != 0 && UNDO_LIMIT + 1 < LastData.Count)
                    {
                        LastData.RemoveAt(0);
                    }
                }
            }
            private void InitializeComponent()
            {
                this.TextChanged += new System.EventHandler(this.textBoxX_TextChanged);
            }
        }
        public class Item
        {
            public String text;
            public int position;
            public Item(String text, int position)
            {
                this.text = text;
                this.position = position;
            }
        }
    }
