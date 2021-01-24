    context.MessageTemplates
      .Where(m => m.NotifyEvent == notifyEvent && m.SendVia == notifyVia.ToString())
      .Select(r => new MessageTemplateDto() {
          TemplateID = r.WhateverTheColumnNameForIdIsInYourMapping,
          r.NotifyEvent //both column and dto property have same name so this can be simplified
          r.SendVia //again, both dto and column seem to have the same name so this can simply be this
          Template = r.WhateverYourColumnNameForTemplateIsInTheContext 
        }
      .ToList();
