           var umbracoHelper = new UmbracoHelper(UmbracoContext.Current);
            var testContentId = 1353; // This is your umbraco node id of your content page
            var publishedContent = umbracoHelper.TypedContent(testContentId);
            if (publishedContent != null)
            {
                foreach (var child in publishedContent.Children)
                {
                    if (child.HasProperty("emailAddress_Contact_Information"))
                    {
                        var emailAddressContactInformation = child.GetProperty("emailAddress_Contact_Information");
                    }
                }
            }
