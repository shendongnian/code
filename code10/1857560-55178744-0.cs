    [XmlElement("printorder_delivery_location")]
    public string DeliveryLocation
    {
      get => deliveryLocation;
      set
      {
        if (value.Length > 10)
          deliveryLocation = value.Substring(0,10).ToUpper();
        else 
          deliveryLocation = value.ToUpper();
      }
    }
