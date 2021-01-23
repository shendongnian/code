    using DocumentFormat.OpenXml.Wordprocessing;
    using DocumentFormat.OpenXml;
    ....
        public Paragraph GenerateParagraph()
        {
            Paragraph paragraph1 = new Paragraph(){ RsidParagraphAddition = "00EA7FFB", RsidParagraphProperties = "00EA7FFB", RsidRunAdditionDefault = "00EA7FFB" };
            ParagraphProperties paragraphProperties1 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId1 = new ParagraphStyleId(){ Val = "ListParagraph" };
            NumberingProperties numberingProperties1 = new NumberingProperties();
            NumberingLevelReference numberingLevelReference1 = new NumberingLevelReference(){ Val = 0 };
            NumberingId numberingId1 = new NumberingId(){ Val = 2 };
            numberingProperties1.Append(numberingLevelReference1);
            numberingProperties1.Append(numberingId1);
            paragraphProperties1.Append(paragraphStyleId1);
            paragraphProperties1.Append(numberingProperties1);
            Run run1 = new Run();
            Text text1 = new Text(){ Space = SpaceProcessingModeValues.Preserve };
            text1.Text = "Item ";
            run1.Append(text1);
            paragraph1.Append(paragraphProperties1);
            paragraph1.Append(run1);
            return paragraph1;
        }
