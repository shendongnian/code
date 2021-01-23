    XDocument xmlSell = XDocument.Parse(x); 
		XNamespace nameSpace = "http://tempuri.org/";
		var venta = from ventas in xmlSell.Descendants(nameSpace + "VentaOnlineInfo")
					select new VentaDigital
					{
						ProcessDate = (DateTime)ventas.Element(nameSpace + "ProcessDate"),
						TicketDate = (DateTime)ventas.Element(nameSpace + "TicketDate"),
						DeliveryDate = (DateTime)ventas.Element(nameSpace + "DeliveryDate")
					};
    
            ventasDigitales.ItemsSource = venta;
