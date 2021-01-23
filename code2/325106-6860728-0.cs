        if (chkWhiteList.Checked)
        {
            string rawUser = rtboxWhiteList.Text;
            string[] list = rawUser.Split(new char[] { ',' });
            using (StreamWriter whiteList = new StreamWriter(cleanDir + @"\white-list.txt"))
                {
                    foreach (string user in list)
                    {
                         whiteList.WriteLine(String.Format("{0}\r\n", user));
                    }
                   
                }
        }
