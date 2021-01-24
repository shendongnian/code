				DataTable SeatNum;
                List<int> SeatNums = (from row in SeatNum.AsEnumerable() select Convert.ToInt32(row["Num"])).ToList();
                bool OutOfRang = false; ;
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (!SeatNums.ToList().Contains(Convert.ToInt32(row.Cells[0].Value)))
                        {
                            OutOfRang = true;
                            row.Cells[0].Style.BackColor = Color.Red;
                            MessageBox.Show("This Num ( " + row.Cells[0].Value.ToString() + " ) not in DataTable list");
                            countSeatsbr++;
                            row.ErrorText = "Not in DataTable list.";
                        }
                    }
                }
                if (OutOfRang)
                {
                    return;
                }
                else
                {
                    DoSomethingElse()
                }
