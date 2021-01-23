    SetStateRequest request = new SetStateRequest();
    request.EntityMoniker = new EntityReference(Invoice.EntityLogicalName, invoice.Id);
    request.State = new OptionSetValue ((int)InvoiceState.Paid);
    request.Status = new OptionSetValue (100001); // Complete
    SetStateResponse response = (SetStateResponse)_service.Execute(request);
