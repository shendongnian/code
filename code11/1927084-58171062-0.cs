     private void saveListViewItems(string path, ListView lv)
        {
            int i = 0;
            string IPFrom;
            string IPFromval;
            string IPTO;
            string IPTOval;
            string Comment;
            string Commentval;
            string CheckState;
            string CheckStateval;
            int IPSectioncount;
            
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(path);
                    while ( i < lv.Items.Count) {
                        if ((lv.Items[i].Selected) || (lv.Items[i].Checked))
                        {
                            CheckStateval = "1";
                        }
                        else
                        {
                            CheckStateval = "0";
                        }
                    CheckState = "";
                    CheckState = "CheckState";
                    CheckState += String.Join(CheckState, i);
                    IPFromval = lv.Items[i].SubItems[0].Text;
                    IPFromval = "";
                    IPFrom = "IPFrom";
                    IPFrom += String.Join(IPFrom, i);
                    IPFromval = lv.Items[i].SubItems[0].Text;
                    IPTOval = "";
                    IPTO = "IPTO";
                    IPTO += String.Join(IPTO, i);
                    IPTOval = lv.Items[i].SubItems[1].Text;
                    Commentval = "";
                    Comment = "Comment";
                    Comment += String.Join(Comment, i);
                    Commentval = lv.Items[i].SubItems[2].Text;
                    data["IP"][CheckState] = CheckStateval;
                    data["IP"][IPFrom] = IPFromval;
                    data["IP"][IPTO] = IPTOval;
                    data["IP"][Comment] = Commentval;
                    
                    i++;
                    }
                    
                    IPSectioncount = lv.Items.Count;
                    data["IP"]["IPSectionCount"] = IPSectioncount.ToString();
                    parser.WriteFile(path, data);
                    
            
        }
       
        private void loadListViewItems(string path, ListView lv)
        {
            string IPFrom;
            string IPTO;
            string Comment;
            string CheckState;
            string IPSectioncount;
            string row="";
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(path);
            IPSectioncount = data["IP"]["IPSectionCount"];
            int m = Int32.Parse(IPSectioncount);
            
            
            int i = 0;
            
            while ( i < m )
            {
                IPFrom = "";
                IPTO = "";
                Comment = "";
                row = "";
                
                IPFrom = "IPFrom";
                IPFrom += String.Join(IPFrom, i);
                IPFrom = data["IP"][IPFrom];
                
                IPTO = "IPTO";
                IPTO += String.Join(IPTO, i);
                IPTO = data["IP"][IPTO];
                
                Comment = "Comment";
                Comment += String.Join(Comment, i);
                Comment = data["IP"][Comment];
                CheckState = "CheckState";
                CheckState += String.Join(CheckState, i);
                CheckState = data["IP"][CheckState];
                row = String.Join(",",IPFrom,IPTO,Comment);
                                lv.Items.Add(new ListViewItem(row.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)));
                                if (CheckState == "1")
                                {
                                    lv.Items[i].Checked = true;
                                }
                
                
                    i++;
                    
                
                   
            }
            
           
        }
