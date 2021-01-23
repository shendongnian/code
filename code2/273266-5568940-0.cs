    Random r = new Random();
    Hashtable values = new Hashtable();
   
    protected void Button1_Click(object sender, EventArgs e)
    {
        int newval = r.Next(10);
       
        values.Add("key",newval);
       
        //foreach (object value in values.Values)
        //{
        //    Response.Write(value.ToString());
        //}
        ArrayList arrayList = new ArrayList(values.Values);
        foreach (int key in arrayList)
        {
            Response.Write(key);
        }
    }
