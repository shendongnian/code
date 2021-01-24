        public void Save(PushTemplate pushTemplate)
        {
            if (pushTemplate.PushTemplateId == 0)
            {
                _applicationContext.PushTemplates.Add(pushTemplate);
            }
            else
            {
                PushTemplate dbEntity = _applicationContext.PushTemplates
                    .Include(x => x.Messages)
                    .FirstOrDefault(x => x.PushTemplateId == pushTemplate.PushTemplateId);
                
                dbEntity.Messages = pushTemplate.Messages;
                
            }
            _applicationContext.SaveChanges();
            }
 
