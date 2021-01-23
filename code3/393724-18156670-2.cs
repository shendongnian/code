    namespace SPCodeSamples
    {
        /// <summary>
        /// Content Type 
        /// </summary>
        public static class SPContentTypeExtensions
        {
            /// <summary>
            /// Creates a content type based on the specified schema.
            /// </summary>
            /// <returns>
            /// An instance of the new content type.
            /// </returns>
            /// <param name="contentTypes">Content Type collection</param>
            /// <param name="schemaXml">A Collaborative Application Markup Language (CAML) string that contains the schema.</param>
            public static SPContentType AddContentTypeAsXml(this SPContentTypeCollection contentTypes, string schemaXml)
            {
                SPContentType contentType;
                using (var xrdr = new XmlTextReader(new StringReader(schemaXml)))
                {
                    xrdr.ProhibitDtd = true;
                    contentType = contentTypes.CreateContentType();
                    LoadXmlInternal(contentType, xrdr);
                    contentTypes.Add(contentType);
                }
                return contentType;
            }
     
     
     
            /// <summary>
            /// Create content type
            /// </summary>
            /// <param name="contentTypes"></param>
            /// <returns></returns>
            private static SPContentType CreateContentType(this SPContentTypeCollection contentTypes)
            {
                var constructor = (typeof(SPContentType)).GetConstructor(
                    BindingFlags.NonPublic | BindingFlags.Instance,
                    null,
                    Type.EmptyTypes,
                    null);
     
                var contentType = (SPContentType)constructor.Invoke(new object[0]);
                contentType.SetWeb(contentTypes.GetWeb());
                return contentType;
            }
     
            /// <summary>
            /// Load schema for content type 
            /// </summary>
            /// <param name="contentType"></param>
            /// <param name="xmlReader"></param>
            private static void LoadXmlInternal(SPContentType contentType, XmlReader xmlReader)
            {
                var loadMethod = contentType.GetType().GetMethod("Load",
                    BindingFlags.NonPublic | BindingFlags.Instance,
                    null,
                    new[] { typeof(XmlReader) },
                    null);
                loadMethod.Invoke(contentType, new object[] { xmlReader });
            }
     
            private static SPWeb GetWeb(this SPContentTypeCollection contentTypes)
            {
                var webProp = typeof(SPContentTypeCollection).GetProperty("Web", BindingFlags.NonPublic | BindingFlags.Instance);
                return  (SPWeb)webProp.GetValue(contentTypes, null);
            }
     
     
            private static void SetWeb(this SPContentType contentType,SPWeb web)
            {
                var webProp = typeof(SPContentType).GetProperty("Web", BindingFlags.NonPublic | BindingFlags.Instance);
                webProp.SetValue(contentType, web, null);
            }
        }
    } 
