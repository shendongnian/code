       protected void Page_Load(object sender, EventArgs e)
       {
          if (!IsPostBack)
          {
             DataBindListBox();
          }
       }
    
       protected void ButtonSubmit_Click(object sender, EventArgs e)
       {
          List<ListItem> selectedItems1 = ListBox1.Items.Cast<ListItem>().Where(li => li.Selected).ToList();
    
          // or
    
          string[] selectedItems2 = (Request.Form[ListBox1.UniqueID] ?? string.Empty).Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
       }
    
       private void DataBindListBox()
       {
          var data = Enumerable.Range(1, 5).Select(i => new { Text = i.ToString(), Value = i.ToString() }).ToList();
    
          ListBox1.DataSource     = data;
          ListBox1.DataTextField  = "Text";
          ListBox1.DataValueField = "Value";
          ListBox1.DataBind();
       }
