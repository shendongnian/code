    protected void btnDownload_Click(object sender, EventArgs e)
    {
        MemoryStream ms = new MemoryStream();
        TextWriter tw = new StreamWriter(ms, System.Text.Encoding.UTF8);
        var structures = KAWSLib.BusinessLayer.Structure.GetStructuresInService();
        // *** comma delimited
        tw.Write("Latitude, Longitude, CountySerial, StructureType, Orientation, District, RoutePre, RouteNo, LocationDesc");
        foreach (var s in structures)
        {
            tw.Write(Environment.NewLine + string.Format("{0:#.000000},{1:#.000000},{2},{3},{4},{5},{6},{7},{8}", s.LATITUDE, s.LONGITUDE, s.CO_SER, EscapeIfNeeded(s.SuperTypeLookup.SHORTDESC), EscapeIfNeeded(s.OrientationLookup.SHORTDESC), s.DISTRICT, s.ROUTE_PREFIX, s.RouteValue, EscapeIfNeeded(s.LOC_DESC)));
        }
        tw.Flush();
        byte[] bytes = ms.ToArray();
        ms.Close();
        Response.Clear();
        Response.ContentType = "application/force-download";
        Response.AddHeader("content-disposition", "attachment;    filename=" + string.Format("kaws-structures-{0:yyyy.MM.dd}.csv", DateTime.Today));
        Response.BinaryWrite(bytes);
        Response.End();
    }
    string EscapeIfNeeded(string s)
    {
        if (s.Contains(","))
        {
            return "\"" + s.Replace("\"", "\"\"") + "\"";
        }
        else
        {
            return s;
        }
    }
