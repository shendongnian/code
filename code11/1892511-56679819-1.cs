     PdfFixedDocument document = new PdfFixedDocument();
 
            PdfStandardFont font = new PdfStandardFont();
            PdfPage page = document.Pages.Add();
            double checkLeft = 50;
            double checkTop = 50;
            double checkWidth = 100;
            double checkHeight = 20;
            PdfStandardFont font = new PdfStandardFont();
           
            PdfPage page = document.Pages.Add();
            BuildCheckBox1("check1", "1", "Checked 1", "Unchecked 1", font, page, new PdfVisualRectangle(checkLeft, checkTop, checkWidth, checkHeight));
            checkTop += 25;
            BuildCheckBox1("check2", "2", "Checked 2", "Unchecked 2", font, page, new PdfVisualRectangle(checkLeft, checkTop, checkWidth, checkHeight));
            checkTop += 25;
            BuildCheckBox1("check3", "2", "Checked 3", "Unchecked 3", font, page, new PdfVisualRectangle(checkLeft, checkTop, checkWidth, checkHeight));
            checkTop += 25;
 
            PdfStringAppearanceOptions sao = new PdfStringAppearanceOptions();
            sao.Brush = new PdfBrush(PdfRgbColor.Black);
            sao.Font = font;
            PdfStringLayoutOptions slo = new PdfStringLayoutOptions();
            slo.X = checkLeft + checkWidth / 2;
            slo.Y = checkTop + checkHeight / 2;
            slo.HorizontalAlign = PdfStringHorizontalAlign.Center;
            slo.VerticalAlign = PdfStringVerticalAlign.Middle;
            page.Graphics.DrawString("Option", sao, slo);
            BuildCheckBox2("check4", "4", page, new PdfVisualRectangle(checkLeft, checkTop, checkWidth, checkHeight));
 
            document.Save("Sample_OvalCheckBox.pdf");
 
        private void BuildCheckBox1(string name, string exportValue, string checkedText, string uncheckedText, PdfFont font, PdfPage page, PdfVisualRectangle location)
        {
            PdfCheckBoxField checkBoxField = new PdfCheckBoxField(name);
            (checkBoxField.Widgets[0] as PdfCheckBoxWidget).ExportValue = exportValue;
            page.Fields.Add(checkBoxField);
            checkBoxField.Widgets[0].VisualRectangle = location;
            (checkBoxField.Widgets[0] as PdfCheckWidget).CheckStyle = PdfCheckStyle.Check;
 
            double lineWidth = 2;
            PdfPen redPen = new PdfPen(PdfRgbColor.Red, lineWidth);
            PdfPen grayPen = new PdfPen(PdfRgbColor.LightGray, lineWidth / 2);
            grayPen.DashPattern = new double[] { 1, 1 };
            PdfBrush pinkBrush = new PdfBrush(PdfRgbColor.LightPink);
            PdfStringAppearanceOptions sao = new PdfStringAppearanceOptions();
            sao.Brush = new PdfBrush(PdfRgbColor.Black);
            sao.Font = font;
            PdfStringLayoutOptions slo = new PdfStringLayoutOptions();
            slo.X = location.Width / 2;
            slo.Y = location.Height / 2;
            slo.HorizontalAlign = PdfStringHorizontalAlign.Center;
            slo.VerticalAlign = PdfStringVerticalAlign.Middle;
 
            PdfAnnotationAppearance checkedAppearance = new PdfAnnotationAppearance(location.Width, location.Height);
            checkedAppearance.Graphics.DrawRoundRectangle(redPen, pinkBrush,
                lineWidth / 2, lineWidth / 2, location.Width - lineWidth, location.Height - lineWidth,
                location.Height - lineWidth, location.Height - lineWidth);
            checkedAppearance.Graphics.DrawString(checkedText, sao, slo);
            (checkBoxField.Widgets[0] as PdfCheckWidget).CheckedStateNormalAppearance = checkedAppearance;
            PdfAnnotationAppearance uncheckedAppearance = new PdfAnnotationAppearance(location.Width, location.Height);
            uncheckedAppearance.Graphics.DrawRoundRectangle(grayPen, pinkBrush,
                lineWidth / 4, lineWidth / 4, location.Width - lineWidth / 2, location.Height - lineWidth / 2,
                location.Height - lineWidth / 2, location.Height - lineWidth / 2);
            uncheckedAppearance.Graphics.DrawString(uncheckedText, sao, slo);
            (checkBoxField.Widgets[0] as PdfCheckWidget).UncheckedStateNormalAppearance = uncheckedAppearance;
        }
 
        private void BuildCheckBox2(string name, string exportValue, PdfPage page, PdfVisualRectangle location)
        {
            PdfCheckBoxField checkBoxField = new PdfCheckBoxField(name);
            (checkBoxField.Widgets[0] as PdfCheckBoxWidget).ExportValue = exportValue;
            page.Fields.Add(checkBoxField);
            checkBoxField.Widgets[0].VisualRectangle = location;
            (checkBoxField.Widgets[0] as PdfCheckWidget).CheckStyle = PdfCheckStyle.Check;
 
           double lineWidth = 2;
            PdfPen redPen = new PdfPen(PdfRgbColor.Red, lineWidth);
            PdfPen grayPen = new PdfPen(PdfRgbColor.LightGray, lineWidth / 2);
            grayPen.DashPattern = new double[] { 1, 1 };
 
            PdfAnnotationAppearance checkedAppearance = new PdfAnnotationAppearance(location.Width, location.Height);
            checkedAppearance.Graphics.DrawRoundRectangle(redPen,
                lineWidth / 2, lineWidth / 2, location.Width - lineWidth, location.Height - lineWidth,
                location.Height - lineWidth, location.Height - lineWidth);
            (checkBoxField.Widgets[0] as PdfCheckWidget).CheckedStateNormalAppearance = checkedAppearance;
            PdfAnnotationAppearance uncheckedAppearance = new PdfAnnotationAppearance(location.Width, location.Height);
            uncheckedAppearance.Graphics.DrawRoundRectangle(grayPen,
                lineWidth / 4, lineWidth / 4, location.Width - lineWidth / 2, location.Height - lineWidth / 2,
                location.Height - lineWidth / 2, location.Height - lineWidth / 2);
            (checkBoxField.Widgets[0] as PdfCheckWidget).UncheckedStateNormalAppearance = uncheckedAppearance;
        }
