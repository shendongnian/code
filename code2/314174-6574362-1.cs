    /// <summary>
    /// Parses registrant XML returned from SharePoint's Lists web service into a collection 
    /// of <see cref="Registrant"/> objects (root element = "listitems").
    /// </summary>
    /// <param name="xml">SharePoint XML</param>
    /// <returns>Collection of Registrant objects, or null if no registrant data could be parsed.</returns>
    public static List<Registrant> ParseSharePointXmlCollection( XElement xml ) {
    
      // Test: Not expected XML element or has no child elements
      if ( !xml.Name.LocalName.Equals( "listitems" ) || !xml.HasElements ) {
        return null;
      }
    
      List<Registrant> regList = null;
    
      XElement data = xml.Element( XName.Get( "data", "urn:schemas-microsoft-com:rowset" ) );
      if ( (data != null) && (data.HasElements) ) {
    
        regList = new List<Registrant>();
    
        IEnumerable<XElement> regXmlNodes = data.Elements( XName.Get( "row", "#RowsetSchema" ) );
        foreach (XElement regXml in regXmlNodes) {
          Registrant reg = ParseSharePointXml( regXml );
          if ( reg != null ) {
            regList.Add( reg );
          }
        }
      }
    
      return regList;
    }
    /// <summary>
    /// Parses registrant XML returned from SharePoint's Lists web service into a single 
    /// <see cref="Registrant"/> object (root element = "row").
    /// </summary>
    /// <param name="xml">SharePoint XML</param>
    /// <returns>A Registrant object, or null if no registrant data could be parsed.</returns>
    public static Registrant ParseSharePointXml( XElement xml ) {
    
      // Test: Not expected XML element or has no attributes
      if ( !xml.Name.LocalName.Equals( "row" ) || !xml.HasAttributes ) {
        return null;
      }
    
      Registrant reg = null;
    
      // Parse ID (if this fails, fail the whole operation)
      if ( xml.Attribute( "ows_ID" ) != null ) {
        reg = new Registrant();
        reg.ID = xml.Attribute( "ows_ID" ).Value;
      }
      else {
        return null;
      }
    
      // Parse First Name
      if ( xml.Attribute( "ows_Q_Registrant_x0020_First_x0020_N" ) != null ) {
        reg.FirstName = xml.Attribute( "ows_Q_Registrant_x0020_First_x0020_N" ).Value;
      }
    
      // Parse Last Name
      if ( xml.Attribute( "ows_Q_Registrant_x0020_Last_x0020_Na" ) != null ) {
        reg.LastName = xml.Attribute( "ows_Q_Registrant_x0020_Last_x0020_Na" ).Value;
      }
    
      // Parse Email
      if ( xml.Attribute( "ows_Q_Registrant_x0020_Email" ) != null ) {
        reg.Email = xml.Attribute( "ows_Q_Registrant_x0020_Email" ).Value;
      }
    
      // Parse Assistant Name
      if ( xml.Attribute( "ows_Q_Asst_x0020_First_x0020_Name" ) != null ) {
        reg.AssistantFirstName = xml.Attribute( "ows_Q_Asst_x0020_First_x0020_Name" ).Value;
      }
      if ( xml.Attribute( "ows_Q_Asst_x0020_Name" ) != null ) {
        reg.AssistantLastName = xml.Attribute( "ows_Q_Asst_x0020_Name" ).Value;
      }
    
      // Parse Assistant Email
      if ( xml.Attribute( "ows_Q_Asst_x0020_Email" ) != null ) {
        reg.AssistantEmail = xml.Attribute( "ows_Q_Asst_x0020_Email" ).Value;
      }
    
      return reg;
    }
