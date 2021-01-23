    try
        {
            ChangeModule cm = new ChangeModule();
            cm.CR_REF_NO = txtCRRefNumber.Text.Trim();
            cm.SLA_DELIVERY_DATE_WAIVER = DateTime.ParseExact(txtSLADeliveryDateWaiver.Text, "dd/MM/yy", null);
            else
                 cm.SLA_DELIVERY_DATE_WAIVER = DBNULL.Value;
        }
        catch (Exception ex)
        {
           throw ex;
        }
