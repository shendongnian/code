    context.MessageTemplates
      .Where(m => m.NotifyEvent == notifyEvent && m.SendVia == notifyVia.ToString())
      .Select(r => new MessageTemplateDto() {
          TemplateID = r.WhateverTheColumnNameForIdIsInYoirMapping,
          r.NotifyEvent //both column and dto property have same name so this can be simplified
        }
      .ToList();
