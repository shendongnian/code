        public static string GetEventEmailText(string emailTemplateName, string contactEmail)
        {
            var eventItem = EventDocumentService.GetCachedItems().FirstOrDefault();
            var contact = ContactInfoProvider.GetContactInfo(contactEmail);
            var resolver = MacroResolver.GetInstance();
            resolver.SetNamedSourceData("Event", eventItem);
            resolver.SetNamedSourceData("Attendee", contact);
            resolver.Settings.EncodeResolvedValues = true;
            var emailTemplate = EmailTemplateProvider.GetEmailTemplate(emailTemplateName, SiteContext.CurrentSiteName);
            return emailTemplate == null ? string.Empty : resolver.ResolveMacros(emailTemplate.TemplateText);
        }
