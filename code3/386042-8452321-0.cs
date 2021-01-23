    public void Button1_Click(object sender, EventArgs e)
    {
         Session["keuze"] = "Nachtwinkel";
    }
    public IList<Business> selectAll()
    {
        var result = (from b in dc.Businesses where b.BusinessType == Session["keuze"]
                      select b).ToList();
        return result;
    }
