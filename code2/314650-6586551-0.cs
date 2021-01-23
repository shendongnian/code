            string WorkingFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string InputFile = Path.Combine(WorkingFolder, "Test.pdf");
            string OutputFile = Path.Combine(WorkingFolder, "Test_enc.pdf");
            using (Stream input = new FileStream(InputFile, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (Stream output = new FileStream(OutputFile, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    PdfReader reader = new PdfReader(input);
                    PdfEncryptor.Encrypt(reader, output, true, null, "secret", PdfWriter.ALLOW_SCREENREADERS);
                }
            }
