    using (var site = new SPSite("http://intranet.contoso.com"))
                {
                    using (var web = site.OpenWeb())
                    {
                        var manifestDoc = new XmlDocument();
                        manifestDoc.Load("ContentTypeManifest.xml");
                        var contentTypeElement = manifestDoc.GetElementsByTagName("ContentType")[0];
                        var ctSchema = contentTypeElement.OuterXml;
                        web.ContentTypes.AddContentTypeAsXml(ctSchema); //create a content type based on the specified schema (XML)
                    }
                }
