    protected void BtnID_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(TextBoxID.Text);
        try
        {
            List<ASPWebApp.CottagesServiceReference.Cottages> cottages = 
               ws.GetCottageInfoByID(id);//.ToList(); it is List<Cottages> already 
            //the next line makes no sense 
            //ListItem cottage = new ListItem(String.Join(".", cottages));
            //What should work
            foreach(Cottages cottage in cottages)
            {
               ListItem li = new ListItem(string.Format("{0}, {1} rooms", cottage.Name, cottage.Rooms)); //add more properties of the cottage here
               BulletedList1.Items.Add(li);
            }
            //no need
            //BulletedList1.DataSource = cottages;
            //BulletedList1.DataBind();
        }
        catch (Exception a)
        {
            //there is no visible console in WebForm application
            //Console.WriteLine(a);
           Trace.Write(a);
        }
    }
