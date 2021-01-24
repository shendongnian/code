        public static void FixTeeChartLicense(Assembly assembly)
        {
            var filename = "steema.resources";
            if (File.Exists(filename))
            {
                return;
            }
            var resourceName = assembly.GetManifestResourceNames().FirstOrDefault(s => s.Contains("TeeChart.licenses"));
            if (resourceName == null)
            {
                return;
            }
            using (var resourceStream = assembly.GetManifestResourceStream(resourceName))
            using (var resourceWriter = new ResourceWriter(filename))
            {
                resourceWriter.AddResource("TeeChart", resourceStream);
            }
        }
