    XDocument xmlSell = XDocument.Parse(x); 
		XNamespace nameSpace = "http://tempuri.org/";
		var venta = from ventas in xmlSell.Descendants(nameSpace + "VentaOnlineInfo")
					select new VentaDigital
					{
						ProcessDate = DateTime.Parse(ventas.Element(nameSpace + "ProcessDate").Value),
						TicketDate = DateTime.Parse(ventas.Element(nameSpace + "TicketDate").Value),
						DeliveryDate = DateTime.Parse(ventas.Element(nameSpace + "DeliveryDate").Value)
					};
    
            ventasDigitales.ItemsSource = venta;
