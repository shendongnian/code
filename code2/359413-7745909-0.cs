        List<String> t = Directory.GetFiles(@"C:\Folder\").ToList();
        List<String> y = new List<string>();
        foreach(var zzz in t)
        {
            y.Add(Path.GetFileName(zzz));
        }
        if(combobox1.Text == "Month")
        {
            List<String> u = (from String s in y where (DateTime.Now.Month - DateTime.Parse(s.Substring(8, 10)).Month) < 1 select s).ToList();
        }
        else if (combobox1.Text == "3 Month")
        {
            List<String> u = (from String s in y where (DateTime.Now.Month - DateTime.Parse(s.Substring(8, 10)).Month) < 3 select s).
                    ToList();
        }
