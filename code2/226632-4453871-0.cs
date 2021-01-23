    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    class Test
    {
        static void Main()        
        {
            string xml = @"<VentaOnlineList 
                              xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' 
                              xmlns:xsd='http://www.w3.org/2001/XMLSchema' 
                              xmlns='http://tempuri.org/'> 
      <VentasList> 
        <VentaOnlineInfo> 
          <ProcessDate>2010-11-01T00:00:00</ProcessDate> 
          <TicketDate>2010-11-01T00:00:00</TicketDate> 
          <DeliveryDate>2010-09-29T00:00:00</DeliveryDate> 
          <DwhLastMonthProcessData>0</DwhLastMonthProcessData> 
          <DwhLastMonthTicketDate>0</DwhLastMonthTicketDate> 
          <PsucLastMonthDeliveryDate>0</PsucLastMonthDeliveryDate> 
          <DwhSelectedMonthProcessData>-6.54</DwhSelectedMonthProcessData> 
          <DwhSelectedMonthTicketDate>-6.54</DwhSelectedMonthTicketDate> 
          <PsucSelectedMonthDeliveryDate>-6.54</PsucSelectedMonthDeliveryDate> 
          <DwhNextMonthProcessData>0</DwhNextMonthProcessData> 
          <DwhNextMonthTicketDate>0</DwhNextMonthTicketDate> 
          <PsucNextMonthDeliveryDate>0</PsucNextMonthDeliveryDate> 
        </VentaOnlineInfo>  
      </VentasList> 
      <Error> 
        <ErrorFlag>false</ErrorFlag> 
      </Error> 
    </VentaOnlineList>";
    
            XDocument xmlSell = XDocument.Parse(xml);
            XNamespace nameSpace = "http://tempuri.org/";
    
            var venta = from ventas in xmlSell.Descendants(nameSpace + "VentaOnlineInfo")
                        select new
                        {
                            ProcessDate = (DateTime)ventas.Element(nameSpace + "ProcessDate"),
                            TicketDate = (DateTime)ventas.Element(nameSpace + "TicketDate"),
                            DeliveryDate = (DateTime)ventas.Element(nameSpace + "DeliveryDate")
                        };
            
            foreach (var x in venta)
            {
                Console.WriteLine(x);
            }
        }
    }
