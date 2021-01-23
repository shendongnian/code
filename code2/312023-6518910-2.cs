        // load the control
        var oTesto = Page.LoadControl("Testo.ascx");
	
        // here you need to run some initialization of your control
        //  because the page_load is not loading now.
	
        // a string writer to write on it
        using(TextWriter stringWriter = new StringWriter())
        {
          // a html writer
          using(HtmlTextWriter GrapseMesaMou = new HtmlTextWriter(stringWriter))
          {
        	// now render the control inside the htm writer
	        oTesto.RenderControl(GrapseMesaMou);
	
          	// here is your control rendered output.
	        strBuild = stringWriter.ToString();
          }
        }
