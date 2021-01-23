private void CreateCampaignAndSend(string apiKey, string listID)
{
            Int32 TemplateID = 100;
            string campaignID =string.Empty;
            
            // compaign Create Options
            campaignCreateOptions campaignCreateOpt = new campaignCreateOptions();
            campaignCreateOpt.list_id = listID;
            campaignCreateOpt.subject = "subject";
            campaignCreateOpt.from_email = "abc@xyz.com";
            campaignCreateOpt.from_name = "abc";
            campaignCreateOpt.template_id = TemplateID;
            // Content
        
            Dictionary<string, string> content = new Dictionary<string, string>();
            content.Add("html_ArticleTitle1", "ArticleTitle1");
            content.Add("html_ArticleTitle2","ArticleTitle2");
            content.Add("html_ArticleTitle3", "ArticleTitle3");
            content.Add("html_Article1", "Article1");
            content.Add("html_Article2", "Article2");
 
            // Conditions
            List<campaignSegmentCondition> csCondition = new List<campaignSegmentCondition>();
            campaignSegmentCondition csC = new campaignSegmentCondition();
            csC.field = "interests-" + 123; // where 123 is the Grouping Id from listInterestGroupings()
            csC.op = "all";
            csC.value = "";
            csCondition.Add(csC);
             
            // Options
            campaignSegmentOptions csOptions = new campaignSegmentOptions();
            csOptions.match = "all";  
            
            
            // Type Options
            Dictionary<string, string> typeOptions = new Dictionary<string, string>();
            typeOptions.Add("offset-units", "days");
            typeOptions.Add("offset-time", "0");
            typeOptions.Add("offset-dir", "after");
            // Create Campaigns
            
            campaignCreate campaignCreate = new campaignCreate(new campaignCreateInput(apiKey, EnumValues.campaign_type.plaintext, campaignCreateOpt, content, csOptions, typeOptions));
            campaignCreateOutput ccOutput = campaignCreate.Execute();
           
            List<Api_Error> error = ccOutput.api_ErrorMessages;  // Catching API Errors
           
            
            if (error.Count <= 0)
            {
                campaignID = ccOutput.result;
               
            }
            else
            {
                foreach (Api_Error ae in error)
                {
                    Console.WriteLine("\n ERROR Creating Campaign : ERRORCODE\t:" + ae.code + "\t ERROR\t:" + ae.error);
                    
                }
            }
        }
