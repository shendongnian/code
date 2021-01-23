    private const string INPUT_STRING = "Bla bla bla bla http://www.site.com and bla bla http://site2.com blabla";
    
    protected void Page_Load ( object sender, EventArgs e ) {
      var outputString = INPUT_STRING;
      Regex regx = new Regex( @"https?://([-\w\.]+)+(:\d+)?(/([\w/_\.]*(\?\S+)?)?)?", RegexOptions.IgnoreCase );
      MatchCollection mactches = regx.Matches( INPUT_STRING );
      foreach ( Match match in mactches ) {
        outputString = outputString.Replace( match.Value, String.Format( "<a href=\"{0}\" target=\"_blank\">{0}</a>", match.Value ) );
      }
      litTextWithLinks.Text = outputString;
    }
