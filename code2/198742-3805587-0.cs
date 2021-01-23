         if (line.StartsWith("5"))
                    {
                        int oldRow = 1;
                        dataGridView1.Rows.Add(itemarray(dataGridView1.Rows[1]));
                        dataGridView1.Rows.RemoveAt(oldRow);
                        dataGridView1.Rows.Add("BatchHeader", line);
                       
                        m_flag = true;
                        StringBuilder sb = new StringBuilder();
                        objfileentry.createFileEntry(Append.FileName, out sb);
                        if (m_flag)
                            dataGridView1.Rows.Add("FileControl", sb.ToString());
                        line = string.Empty;
                    }
