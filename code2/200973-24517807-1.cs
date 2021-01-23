    protected void btnShippingCalculate_Click(object sender, EventArgs e)
        {
            
    
                string xmlresult = CalculateCharge("10", "10", "10", "3216","3217" ,"5", "AUS_PARCEL_REGULAR");
                DataSet ds = new DataSet();
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.LoadXml(xmlresult);
                ds.ReadXml(new System.IO.StringReader(doc.OuterXml));
                GridView1.DataSource = ds;
                GridView1.DataBind();
             
            }
