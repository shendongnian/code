        private void lBxDostepneOpcje_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            ListViewItem item = lBxDostepneOpcje.FocusedItem as ListViewItem;
            ListView.SelectedIndexCollection lista = lBxDostepneOpcje.SelectedIndices;
            foreach (Int32 i in lista)
            {
                lBxDostepneOpcje.Items[i].BackColor = Color.White;
            }
            if (item != null)
            {
                item.Selected = false;
                if (item.Index == 0)
                {
                }
                else
                {
                    lBxDostepneOpcje.Items[item.Index-1].BackColor = Color.White;
                }
                if (lBxDostepneOpcje.Items[item.Index].Focused == true)
                {
                    lBxDostepneOpcje.Items[item.Index].BackColor = Color.LightGreen;
                    if (item.Index < lBxDostepneOpcje.Items.Count-1)
                    {
                        lBxDostepneOpcje.Items[item.Index + 1].BackColor = Color.White;
                    }
                }
                else if (lBxDostepneOpcje.Items[item.Index].Focused == false)
                {
                    lBxDostepneOpcje.Items[item.Index].BackColor = Color.Blue;
                }
            }
           
        }
