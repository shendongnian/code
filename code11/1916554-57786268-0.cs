 //build recipients
                recipients.Signers = signers.Aggregate(new List<Signer>(), (newSigners, signer) =>
                {
                    string recipeintId = Guid.NewGuid().ToString();
                    var newSigner = new Signer
                    {
                        Email = signer.Email,
                        Name = signer.FullName,
                        RoleName = signer.SigningRole,
                        ClientUserId = signer.Email,
                        RecipientId = recipeintId //Int or Guid expected                      
                    };
                    newSigners.Add(newSigner);
                    return newSigners;
                });
                var addedRecipient = await envelopesApi.CreateRecipientAsync(await AccountAsync(), envelopeId, recipients); //adding recipients
                var templateInfo = await envelopesApi.ListTemplatesAsync(await AccountAsync(), envelopeId, new EnvelopesApi.ListTemplatesOptions { include = "applied" });
                //envelope is created using one template only
                    var templateRecipients = await templatesApi.ListRecipientsAsync(await AccountAsync(), templateInfo.Templates.FirstOrDefault().TemplateId, new ListRecipientsOptions { includeTabs = "true" });
                    foreach (var signer in recipients.Signers)
                    {
                        Signer templateSigner = templateRecipients.Signers.FirstOrDefault(w => w.RoleName.ToLower() == signer.RoleName.ToLower());
                        Tabs tabs =BuildRecipientTabs(signer.RecipientId, templateSigner.Tabs);
                        var t=  await envelopesApi.CreateTabsAsync(await AccountAsync(), envelopeId, signer.RecipientId, tabs);
                    }
                
            
