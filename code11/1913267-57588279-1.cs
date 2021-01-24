`
private static async Task<List<Tuple<NotificationToSend, bool>>> SendNotificationsAsync(IEnumerable<NotificationToSend> notificationsToSend)
{
    var tuples = new List<Tuple<NotificationToSend, bool>>();
    using (var smtpClient = new SmtpClient())
    {
        foreach (var notification in notificationsToSend)
        {
            bool sentSuccessfully = SendNotificationAsync(smtpClient, notification);
            var tuple = new Tuple<NotificationToSend, bool>(notification, sentSuccessfully);
            tuples.Add(tuple);
        }
    }
    return tuples;
}
private static async Task<bool> SendNotificationAsync(SmtpClient smtpClient, NotificationToSend notification)
{
    var mailMessage = new MailMessage
    {
        Subject = notification.Subject,
        Body = $"{notification.Text} <br /> This notification was sent automatically",
        IsBodyHtml = true
    };
    mailMessage.To.Add(notification.ToEmail);
    try
    {
        await smtpClient.SendMailAsync(mailMessage);
        return true;
    }
    catch (Exception e)
    {
        // Here I also plan to log the exception
        return false;
    }
}
