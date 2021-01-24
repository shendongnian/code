            // Data for this method
            // signerEmail 
            // signerName
            // ccEmail
            // ccName
            // accessToken
            // basePath
            // accountId
            // templateId
            var config = new Configuration(new ApiClient(basePath));
            config.AddDefaultHeader("Authorization", "Bearer " + accessToken);
            EnvelopesApi envelopesApi = new EnvelopesApi(config);
            EnvelopeDefinition envelope = MakeEnvelope(signerEmail, signerName, ccEmail, ccName, templateId);
            EnvelopeSummary result = envelopesApi.CreateEnvelope(accountId, envelope);
            return result.EnvelopeId;
        }
        private EnvelopeDefinition MakeEnvelope(string signerEmail, string signerName, 
            string ccEmail, string ccName, string templateId)
        {
            // Data for this method
            // signerEmail 
            // signerName
            // ccEmail
            // ccName
            // templateId
            EnvelopeDefinition env = new EnvelopeDefinition();
            env.TemplateId = templateId;
            TemplateRole signer1 = new TemplateRole();
            signer1.Email = signerEmail;
            signer1.Name =  signerName;
            signer1.RoleName = "signer";
            TemplateRole cc1 = new TemplateRole();
            cc1.Email = ccEmail;
            cc1.Name = ccName;
            cc1.RoleName = "cc";
            env.TemplateRoles = new List<TemplateRole> { signer1, cc1 };
            env.Status = "sent";
            return env;
        }
        // ***DS.snippet.0.end
