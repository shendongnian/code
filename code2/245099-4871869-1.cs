        public void InvertSelection(ListBox objLstbox)
        {
            if(objLstbox == null) return;
            for (int i = 0; i < objLstbox.Items.Count; i++)
                objLstbox.SetSelected(i, !objLstbox.GetSelected(i));
        }
        private void btnInvert_Click(object sender, EventArgs e)
        {
            InvertSelection(listBox1);
            InvertSelection(listBox2);
            InvertSelection(listBox3);
        }
