    public static class MailMessageExtensions
    {
        private static readonly BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
        private static readonly Type mailWriter = typeof(SmtpClient).Assembly.GetType("System.Net.Mail.MailWriter");
        private static readonly ConstructorInfo mailWriterConstructor = mailWriter.GetConstructor(flags, null, new[] { typeof(Stream) }, null);
        private static readonly MethodInfo closeMethod = mailWriter.GetMethod("Close", flags);
        private static readonly MethodInfo sendMethod = typeof(MailMessage).GetMethod("Send", flags);
        public static MemoryStream RawMessage(this MailMessage m)
        {
            var result = new MemoryStream();
            var mailWriter = mailWriterConstructor.Invoke(new object[] { result });
            sendMethod.Invoke(m, flags, null, new[] { mailWriter, true }, null);
            closeMethod.Invoke(mailWriter, flags, null, new object[] { }, null);
            return result;
        }
    }
