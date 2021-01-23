    		public static void Main()
    		{
    			var paramId = "External App Interface";
    			var toParameterValue = "DISABLED";
    
    			var xdoc = XDocument.Parse(@"
    <EquipmentParameterModified dateTime='2011-04-06T12:03:10.00+01:00' parameter='ExtApp'>
      <Extensions ParameterId='External App Interface' FromParameterValue='' ToParameterValue='DISABLED'/>
    </EquipmentParameterModified>");
    
    			var ret = xdoc.Root
    				.Elements("Extensions")
    				.Where(e => e.Attribute("ParameterId").Value == paramId &&
    							e.Attribute("ToParameterValue").Value == toParameterValue)
    				.FirstOrDefault();
    
    			if (ret != null)
    				Console.WriteLine(ret.Name);
    
    		}
