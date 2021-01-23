    string xmlSource = @"<?xml version=""1.0""?>
    <ArrayOfBusiness xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
      <Business>
     <Name>Company Name 1</Name>
     <AddressList>
       <Address>
      <AddressLine>123 Main St.</AddressLine>
       </Address>
     </AddressList>
      </Business>
      <Business>
     <Name>Company Name 2</Name>
     <AddressList>
       <Address>
      <AddressLine>1 Elm St.</AddressLine>
       </Address>
       <Address>
      <AddressLine>2 Elm St.</AddressLine>
       </Address>
     </AddressList>
      </Business>
    </ArrayOfBusiness>"; 
    
    XElement xml = XElement.Parse(xmlSource); 
    // xml.Dump(); 
    
    var csvs = (
    from el in xml.Elements("Business")
    let name = el.Element("Name").Value
    let addr = (from a in el.Element("AddressList").Elements("Address").Elements("AddressLine")  select a.Value)
    select string.Format("{0},{1},{2}", name, addr.ElementAtOrDefault(0), addr.ElementAtOrDefault(1))
    ); 
    
    csvs.Dump(); 
