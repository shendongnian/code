    var javaBaseDate = new DateTime(1970, 1, 1);
    var myDate = DateTime.Now;
    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Date", 
      String.Format(
      System.Globalization.CultureInfo.InvariantCulture,
      "var myDate = new Date({0});",
       (myDate - javaBaseDate).TotalMilliseconds
       ), true);
