         public void Save(PushTemplate pushTemplate)
        {
            if (pushTemplate.PushTemplateId == 0)
            {
                _applicationContext.PushTemplates.Add(pushTemplate);
            }
            else
            {
                PushTemplate dbEntity = _applicationContext.PushTemplates.Find(pushTemplate.PushTemplateId);
                // clean old relations 
                _applicationContext.TemplateMessages
                    .RemoveRange(_applicationContext.TemplateMessages
                        .Where(x => x.PushTemplate.PushTemplateId == dbEntity.PushTemplateId));
                dbEntity.Messages = pushTemplate.Messages;
            }
            _applicationContext.SaveChanges();
        }
