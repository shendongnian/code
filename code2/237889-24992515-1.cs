        private static void Test()
        {
            var localGhostscriptDll = Path.Combine(Environment.CurrentDirectory, "gsdll64.dll");
            var localDllInfo = new GhostscriptVersionInfo(localGhostscriptDll);
            int desired_x_dpi = 96;
            int desired_y_dpi = 96;
            string inputPdfPath = "test.pdf";
            string outputPath = Environment.CurrentDirectory;
            GhostscriptRasterizer _rasterizer = new GhostscriptRasterizer();
            _rasterizer.Open(inputPdfPath, localDllInfo, false);
            for (int pageNumber = 1; pageNumber <= _rasterizer.PageCount; pageNumber++)
            {
                string pageFilePath = Path.Combine(outputPath, "Page-" + pageNumber.ToString() + ".png");
                Image img = _rasterizer.GetPage(desired_x_dpi, desired_y_dpi, pageNumber);
                img.Save(pageFilePath, ImageFormat.Png);
            }
            _rasterizer.Close();
        }
