            //Create the process
            using (Process ns = new Process())
            {
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[] {
                        new DataColumn("Protocol"),
                        new DataColumn("Local Address"),
                        new DataColumn("Foreign Address"),
                        new DataColumn("State"),
                        new DataColumn("PID"),
                        new DataColumn("Process Name"),
                    });
                ProcessStartInfo psi = new ProcessStartInfo("netstat.exe", "-ano");
                psi.RedirectStandardOutput = true;
                psi.UseShellExecute = false;
                ns.StartInfo = psi;
                // Run it, and read the results
                ns.Start();
                using (StreamReader r = ns.StandardOutput)
                {
                    string output = r.ReadToEnd();
                    ns.WaitForExit();
                    //Parse those results into a DataTable, polling the Process info
                    string[] lines = output.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                    foreach (string line in lines)
                    {
                        string[] elements = line.Split(' ');
                        if (elements.Length < 5) continue;
                        if (elements.Contains("Proto")) continue;
                        DataRow dr = dt.NewRow();
                        List<string> validElements = new List<string>();
                        //Weed out empty elements.
                        foreach (string element in elements)
                        {
                            //skip blanks
                            if (element.Trim() == "") continue;
                            validElements.Add(element);
                        }
                        foreach (string element in validElements)
                        {
                            foreach (DataColumn dc in dt.Columns)
                            {
                                // fill in the buckets. Note that UDP doesn't have a state
                                if (dr["Protocol"].ToString() == "UDP" && dc.ColumnName == "State") continue;
                                if (dr[dc] == DBNull.Value)
                                {
                                    dr[dc] = element;
                                    break;
                                }
                            }
                        }
                        dr["Process Name"] = Process.GetProcessById(int.Parse(dr["PID"].ToString())).ProcessName;
                        dt.Rows.Add(dr);
                    }
                }
            }
