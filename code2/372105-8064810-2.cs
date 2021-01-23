         	public static void Main()
    		{
    			var paramId = "External App Interface";
    			var toParameterValue = "DISABLED";
    
    			XmlDocument xmlDoc = new XmlDocument();
    			xmlDoc.LoadXml(@"
    <EquipmentParameterModified dateTime='2011-04-06T12:03:10.00+01:00' parameter='ExtApp'>
      <Extensions ParameterId='External App Interface' FromParameterValue='' ToParameterValue='DISABLED'/>
    </EquipmentParameterModified>");
    
    			XmlNode node = xmlDoc.GetElementsByTagName("Extensions")[0];
    			if (node.Attributes["ParameterId"].Value == paramId &&
    				node.Attributes["ToParameterValue"].Value == toParameterValue)
    			{
    				Console.WriteLine("Found matching node:" + node.Name);
    				return;
    			}
    		}
