        void Form1_Load(object sender, EventArgs e)
        {
            listView1.OwnerDraw = true;
            listView1.DrawColumnHeader +=listView1_DrawColumnHeader;
            listView1.DrawSubItem+=listView1_DrawSubItem;
        }
        private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawText();
        }
        private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawText(TextFormatFlags.Right);
        }
