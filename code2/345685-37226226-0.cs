        ChangeModule cm = new ChangeModule();
        cm.CR_REF_NO = txtCRRefNumber.Text.Trim();
        cm.SLA_DELIVERY_DATE_WAIVER = DateTime.ParseExact(txtSLADeliveryDateWaiver.Text, "dd/MM/yy", null);
        else /*This else part is causing problem since I assigned null*/
             cm.SLA_DELIVERY_DATE_WAIVER = null;
    }
    catch (Exception ex)
    {
       throw ex;
    }
