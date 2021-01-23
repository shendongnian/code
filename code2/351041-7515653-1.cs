        private static MemoryStream ConvertMailMessageToMemoryStream(MailMessage message)
        {
            BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
            Assembly assembly = typeof(SmtpClient).Assembly;
            MemoryStream stream = new MemoryStream();
            Type mailWriterType = assembly.GetType("System.Net.Mail.MailWriter");
            ConstructorInfo mailWriterContructor = mailWriterType.GetConstructor(flags, null, new[] { typeof(Stream) }, null);
            object mailWriter = mailWriterContructor.Invoke(new object[] { stream });
            MethodInfo sendMethod = typeof(MailMessage).GetMethod("Send", flags);
            sendMethod.Invoke(message, flags, null, new[] { mailWriter, true }, null);
            MethodInfo closeMethod = mailWriter.GetType().GetMethod("Close", flags);                
            closeMethod.Invoke(mailWriter, flags, null, new object[] { }, null);
            return stream;
        }
