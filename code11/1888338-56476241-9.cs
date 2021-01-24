    builder.RegisterType<EmailSender>() 
           .Named<ISender>("email")
           .WithParameter("smtpClient", emailSmtp);
    builder.RegisterType<FaxSender>()
           .Named<ISender>("fax")
           .WithParameter("smtpClient", faxSmtp);
    builder.RegisterType<BasePage>()
           .AsSelf()
           .WithProperties(new Parameter[] {
               new ResolvedParameter(
                 (pi, c) => {
                   PropertyInfo ppi = null;
                   if (pi.TryGetDeclaringProperty(out ppi)) {
                     return ppi.Name == "SmtpClient";
                   } else {
                     return false;
                   }
                 },
                 (pi, c) => c.ResolveNamed<ISender>("email")),
               new ResolvedParameter(
                 (pi, c) => {
                   PropertyInfo ppi = null;
                   if (pi.TryGetDeclaringProperty(out ppi)) {
                     return ppi.Name == "FaxClient";
                   } else {
                     return false;
                   }
               },
               (pi, c) => c.ResolveNamed<ISender>("fax"))
           });
