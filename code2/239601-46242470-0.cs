        // Certificates content has 64 characters per lines
        private const int MaxCharactersPerLine = 64;
        /// <summary>
        /// Export a certificate to a PEM format string
        /// </summary>
        /// <param name="cert">The certificate to export</param>
        /// <returns>A PEM encoded string</returns>
        public static string ExportToPem(this X509Certificate2 cert)
        {
            var builder = new StringBuilder();
            var certContentBase64 = Convert.ToBase64String(cert.Export(X509ContentType.Cert));
            // Calculates the max number of lines this certificate will take.
            var certMaxNbrLines = Math.Ceiling((double)certContentBase64.Length / MaxCharactersPerLine);
            builder.AppendLine("-----BEGIN CERTIFICATE-----");
            for (var index = 0; index < certMaxNbrLines; index++)
            {
                var maxSubstringLength = index * MaxCharactersPerLine + MaxCharactersPerLine > certContentBase64.Length
                    ? certContentBase64.Length - index * MaxCharactersPerLine
                    : MaxCharactersPerLine;
                builder.AppendLine(certContentBase64.Substring(index * MaxCharactersPerLine, maxSubstringLength));
            }
            builder.AppendLine("-----END CERTIFICATE-----");
            return builder.ToString();
        }
