    DateTime dt;
    if (DateTime.TryParseExact(txtSLADeliveryDateWaiver.Text,
                               "dd/MM/yy", null, DateTimeStyles.None, out dt))
    {
        cm.SLA_DELIVERY_DATE_WAIVER = dt;
    }
    else
    {
        cm.SLA_DELIVERY_DATE_WAIVER = null;
    }
