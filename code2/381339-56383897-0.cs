    List<Pay> intersectedPays = new List<Pay>();
    foreach (Pay o in olist)
    {
        var intersectedPay = nlist.Where(n => n.EventId == o.EventId).SingleOrDefault();
        if (intersectedPay != null)
            intersectedPays.Add(intersectedPay);
    }
					
	List<Pay> result = intersectedPays;
