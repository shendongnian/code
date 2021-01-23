    // XmlDoc to hold custom Xml within each node
            XmlDocument innerXml = new XmlDocument();
            try
            {
                // Parse inner xml of each item and create objects
                foreach (var faq in faqs)
                {
                    innerXml.LoadXml(faq.InnerXml);
                    
                    FAQ oFaq = new FAQ();
                    #region Fields
                    // Get Title value if node exists and is not null
                    if (innerXml.SelectSingleNode("root/title") != null)
                    {
                        oFaq.Title = innerXml.SelectSingleNode("root/title").InnerXml;
                    }
                    // Get Details value if node exists and is not null
                    if (innerXml.SelectSingleNode("root/details") != null)
                    {
                        oFaq.Description = innerXml.SelectSingleNode("root/details").InnerXml;
                    }
                    #endregion
                    result.Add(oFaq);
                }
            }
            catch (Exception ex)
            {
                // Handle Exception
            } 
