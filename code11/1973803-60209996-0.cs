for (int i = 0; i < 1; i ++)
{
    foreach (string line in InputNamesLine)
                     {
                        if (line != "")
                        {
                            string[] columns = line.Split(' ');
                            string column1 = columns[0];
                            string column2 = columns[1];
                            //oSheet.Cells[1][i + 1] = i;
                            oSheet.Cells[1][i + 2] = column1;
                            oSheet.Cells[2][i + 2] = column2;
                            i = i+1;
                        }
                    }
                }
