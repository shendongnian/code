    public class ServicePdf : IServicePdf
    {
        private readonly IConfiguration _configuration;
        public ServicePdf(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public PdfGlobalOptions Options { set; get; }
        /// <summary>
        /// Pertmet la génération d'un fichier PDF
        /// </summary>
        /// <param name="url">l'url à convertir exp : http://www.google.fr</param>
        /// <param name = "filename" > Nom du fichier pdf en output</param>
        /// <returns>byte[] pdf en cas de succès, le message d'erreur en cas d'echec</returns>
        public object GeneratePDF(string url, string filename)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = _configuration.GetSection("wkhtmltopdf").GetSection("Path").Value + _configuration.GetSection("wkhtmltopdf").GetSection("Program").Value;
            StringBuilder arguments = new StringBuilder();
            arguments.Append("--page-size ");
            arguments.Append("A4");
            arguments.Append(" ");
            if (Options.Orientation != PdfOrientation.Portrait)
            {
                arguments.Append("--orientation Landscape");
                arguments.Append(" ");
            }
            if (Options.MarginLeft.HasValue)
            {
                arguments.Append("--margin-left ");
                arguments.Append(Options.MarginLeft);
                arguments.Append(" ");
            }
            if (Options.MarginTop.HasValue)
            {
                arguments.Append("--margin-top ");
                arguments.Append(Options.MarginTop);
                arguments.Append(" ");
            }
            if (Options.MarginRight.HasValue)
            {
                arguments.Append("--margin-right ");
                arguments.Append(Options.MarginRight);
                arguments.Append(" ");
            }
            if (Options.MarginBottom.HasValue)
            {
                arguments.Append("--margin-bottom ");
                arguments.Append(Options.MarginBottom);
                arguments.Append(" ");
            }
            if (Options.PageWidth.HasValue)
            {
                arguments.Append("--page-width ");
                arguments.Append(Options.PageWidth);
                arguments.Append(" ");
            }
            if (Options.PageHeight.HasValue)
            {
                arguments.Append("--page-height ");
                arguments.Append(Options.PageHeight);
                arguments.Append(" ");
            }
            if (Options.HeaderSpacing.HasValue)
            {
                arguments.Append("--header-spacing ");
                arguments.Append(Options.HeaderSpacing);
                arguments.Append(" ");
            }
            if (Options.FooterSpacing.HasValue)
            {
                arguments.Append("--footer-spacing ");
                arguments.Append(Options.FooterSpacing);
                arguments.Append(" ");
            }
            if (!string.IsNullOrEmpty(Options.Header))
            {
                arguments.Append("--header-html ");
                arguments.Append(Options.Header);
                arguments.Append(" ");
            }
            if (!string.IsNullOrEmpty(Options.Footer))
            {
                arguments.Append("--footer-html ");
                arguments.Append(Options.Footer);
                arguments.Append(" ");
            }
            
            arguments.Append(url);
            arguments.Append(" ");
            arguments.Append(System.IO.Path.GetTempPath());
            arguments.Append(filename);
            startInfo.Arguments = arguments.ToString();
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            process.StartInfo = startInfo;
            process.Start();
            var errors = process.StandardError.ReadToEnd();
            if (System.IO.File.Exists(System.IO.Path.GetTempPath() + filename))
            {
                byte[] pdf = System.IO.File.ReadAllBytes(System.IO.Path.GetTempPath() + filename);
                return pdf;
            }
            return errors;
        }
    }
