    private void cmbDirectoryType_Format(object sender, System.Windows.Forms.ListControlConvertEventArgs e)
    {
	  if (e.DesiredType == typeof(string))
	  {
	    string str1 = ((Datarow)e.ListItem)("Col1").ToString();
        string str2 = ((Datarow)e.ListItem)("Col2").ToString();
        e.Value = str1  + " " + str2;
	  }
    }
