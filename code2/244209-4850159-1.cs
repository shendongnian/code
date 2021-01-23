    using System.IO;
    using System.Text;
    using Microsoft.Exchange.WebServices.Data;
    EmailMessage message = EmailMessage.Bind(service, new ItemId(item.Id.ToString()),
        new PropertySet(BasePropertySet.IdOnly, ItemSchema.Attachments));
    using (StreamWriter writer = new StreamWriter(String.Format(
           CultureInfo.InvariantCulture, @"C:\CodeCopy\Email\temp\{0}.body.txt",
           item.Id.ToString().Replace('\\', '_')))) {
        writer.Write(message.Body.ToString());
    }
