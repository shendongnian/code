    private void Exportar()
        {
            Encoding encoding = Encoding.UTF8;
    
            saveFileDialog1.Filter = "Arquivo Excel (*.xls)|*.xls";
    		saveFileDialog1.FileName = "logs";
    		saveFileDialog1.Title = "Exportar para Excel";
    		StringBuilder sb = new StringBuilder();
            foreach (ColumnHeader ch in lstPesquisa.Columns)
    		{
                sb.Append(ch.Text + "\t");
    		}
    		sb.AppendLine();
            foreach (ListViewItem lvi in lstPesquisa.Items)
    		{
    			foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
    			{
                    if (lvs.Text.Trim() == string.Empty)
                    {
                        sb.Append(" ");
                    }
                    else
                    {
                        string ITEM = Regex.Replace(lvs.Text, @"\t|\n|\r", "");//remover novas linhas
                        sb.Append(ITEM + "\t");
                    }
    			}
    			sb.AppendLine();
    		}
    		DialogResult dr = saveFileDialog1.ShowDialog();
    		if (dr == DialogResult.OK)
    		{
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName, false, Encoding.UTF32);
    			sw.Write(sb.ToString());
    			sw.Close();
    		}
        }
