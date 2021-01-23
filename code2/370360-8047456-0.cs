    var service = new ExchangeService(ExchangeVersion.Exchange2010_SP1)
			              {
							  UseDefaultCredentials = true,
							  Url = new Uri("https://casserver/ews/exchange.asmx")
			              };
    Item item = Item.Bind(service, new Itemid(msgid));
    item.Subject = "test";
    item.Update(ConflictResolutionMode.AutoResolve);
