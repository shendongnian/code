      static readonly Dictionary<string, string> _columnMappings = new Dictionary<string, string>();
      static ClassName() //static constructor
      {
         _columnMappings.Add("FIRM", "COMPANY");
         _columnMappings.Add("COMPANY", "COMPANY");
         _columnMappings.Add("COMPANYNAME", "COMPANY");
         _columnMappings.Add("BUSINESS", "COMPANY");
         _columnMappings.Add("ADDRESS1", "LINE1");
         _columnMappings.Add("LINE1", "LINE1");
      }
