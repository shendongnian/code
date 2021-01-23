    /// <summary>
    /// Uses reflection to get the raw content out of a MailMessage.
    /// </summary>
    public static class MailMessageExtensions
    {
        private static readonly BindingFlags Flags = BindingFlags.Instance | BindingFlags.NonPublic;
        private static readonly Type MailWriter = typeof(SmtpClient).Assembly.GetType("System.Net.Mail.MailWriter");
        private static readonly ConstructorInfo MailWriterConstructor = MailWriter.GetConstructor(Flags, null, new[] { typeof(Stream) }, null);
        private static readonly MethodInfo CloseMethod = MailWriter.GetMethod("Close", Flags);
        private static readonly MethodInfo SendMethod = typeof(MailMessage).GetMethod("Send", Flags);
        /// <summary>
        /// The raw contents of this MailMessage as a MemoryStream.
        /// </summary>
        /// <param name="self">The caller.</param>
        /// <returns>A MemoryStream with the raw contents of this MailMessage.</returns>
        public static MemoryStream RawMessage(this MailMessage self)
        {
            var result = new MemoryStream();
            var mailWriter = MailWriterConstructor.Invoke(new object[] { result });
            SendMethod.Invoke(self, Flags, null, new[] { mailWriter, true, false }, null);
            CloseMethod.Invoke(mailWriter, Flags, null, new object[] { }, null);
            return result;
        }
    }
