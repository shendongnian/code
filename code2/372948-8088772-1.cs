    // just get the item
    var userForm = (
        from i in dataContext.RequestFormItems
        join c in dataContext.RequestFormInstances on i.TypeGuid equals c.TypeGuid
        where i.Id == FormID
        select i).FirstOrDefault();
    // parse the XML
    var xml = XElement.Parse(userForm.XML);
    RFDateTimeCompleted = xml.Element("DateTimeCompleted").Value;
    xml.Element("DateTimeCompleted").Value = "New Data";
    // and finally, because you're again just changing XML 
    // unrelated to the context, update the original object
    userForm.XML = xml.ToString();
    context.SubmitChanges();
