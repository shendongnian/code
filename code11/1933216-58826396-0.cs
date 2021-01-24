     private static Stream GetMSLogoAssembly()
        {
            Stream stream = null;
            Type typeOf = MethodBase.GetCurrentMethod().DeclaringType;
            Assembly assm = typeOf.Assembly;
            foreach (var resourceName in assm.GetManifestResourceNames())
            {
                if (resourceName.Contains("mediashuttle-logo.png"))
                {
                    stream = assm.GetManifestResourceStream(resourceName);
                }
            }
            return stream;
        }
        private static Stream GetDownloadArrowAssembly()
        {
            Stream stream = null;
            Type typeOf = MethodBase.GetCurrentMethod().DeclaringType;
            Assembly assm = typeOf.Assembly;
            foreach (var resourceName in assm.GetManifestResourceNames())
            {
                if (resourceName.Contains("email-download-button.png"))
                {
                    stream = assm.GetManifestResourceStream(resourceName);
                }
            }
            return stream;
        }
