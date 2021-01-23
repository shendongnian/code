    class Items
    {
      public int itemID { get; set; }
      public string itemName { get; set; }
      public int itemNo { get; set; }
      public string pkgdate { get; set; }
    }
    
    class Program
    {
      private static string connectionString = "...";
      
      static void Main(string[] args)
      {
        string streadpath = @"I:\itemdata.txt";
        string stwritepath = @"I:\itemdata1.txt";
        string stcopypath = @"I:\itemdata2.txt";
        
        List<Items> li_all = new List<Items>();
        List<Items> li_db = new List<Items>();
        List<Items> li_valid = new List<Items>();
        List<Items> li_invalid = new List<Items>();
        
        li_all = stread_file(streadpath);
        li_invalid = validate(li_all);
        li_db = retrievefromDB();
        bool x = stwrite_invalid(li_db, stwritepath);
        bool y = stcopy_file(streadpath, stcopypath);
      }
      
      static List<Items> stread_file(string stpath)
      {
        List<Items> stli = new List<Items>();
        using (StreamReader SR = new StreamReader(stpath))
        {
          string line = "";
          while ((line = SR.ReadLine()) != null)
          {
            string[] linevalues = line.Split(',');
            Items obj = new Items();
            obj.itemID = int.Parse(linevalues[0]);
            obj.itemName = linevalues[1];
            obj.itemNo = int.Parse(linevalues[2]);
            obj.pkgdate = linevalues[3];
            stli.Add(obj);
          }
        }
        return stli;
      }
      
      static List<Items> validate(List<Items> stli)
      {
        List<Items> li_valid = new List<Items>();
        List<Items> li_invalid = new List<Items>();
        DateTime parsed;
        foreach (Items stit in stli)
        {
          if(DateTime.TryParseExact(stit.pkgdate, "MM/dd/yyyy",
          CultureInfo.InvariantCulture,
          DateTimeStyles.None, out parsed))
          {
            li_valid.Add(stit);
          }
          else
          {
            li_invalid.Add(stit);
          }
        }
        InsertDataToDb(li_valid);
        return li_invalid;
      }
      
      static bool stwrite_invalid(List<Items> stli,string stpath)
      {
        using (StreamWriter SW = new StreamWriter(stpath))
        {
          foreach(Items stit in stli)
          {
            SW.WriteLine(stit.itemID + "," + stit.itemName + "," + stit.itemNo + "," + stit.pkgdate);
          }
        }
        return true;
      }
      
      static bool stcopy_file(string stsourcepath, string stdestinationpath)
      {
        File.Copy(stsourcepath, stdestinationpath);
        return true;
      }
      
      static void InsertDataToDb(List<Items> stli)
      {
        var records = stli;
        using (SqlConnection con = new SqlConnection(connectionString))
        {
          StringBuilder nonQuery = new StringBuilder();
          foreach (var item in records)
          {
            nonQuery.AppendFormat("INSERT INTO dbo.Smartphone VALUES ({0}, '{1}', {2}, '{3}');",
            item.itemID,
            item.itemName,
            item.itemNo,
            item.pkgdate);
          }
          SqlCommand cmd = new SqlCommand(nonQuery.ToString(),con);
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
        }
      }
      
      static List<Items> retrievefromDB()
      {
        List<Items> stli = new List<Items>();
        DataTable dt = new DataTable();
        SqlConnection con = new SqlConnection(connectionString);
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from dbo.Smartphone", con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        con.Close();
        if (dt.Rows.Count > 0)
        {
          for (int i = 0; i < dt.Rows.Count; i++)
          {
            Items obj = new Items();
            obj.itemID = (int)dt.Rows[i]["ID"];
            obj.itemName = dt.Rows[i]["Name"].ToString();
            obj.itemNo = (int)dt.Rows[i]["Num"];
            obj.pkgdate = dt.Rows[i]["RDate"].ToString();
            stli.Add(obj);
          }
        }
        return stli;
      }
    }
