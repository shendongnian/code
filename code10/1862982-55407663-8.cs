    public void SetStyleToTarget(string targetFile, XDocument newStyles)
    {
        // open with write permissions
        using (var doc = WordprocessingDocument.Open(targetFile, true))
        {
                // add or get the style definition part
                StyleDefinitionsPart styleDefn = null;
                if (doc.MainDocumentPart.StyleDefinitionsPart == null)
                {
                    styleDefn = doc.MainDocumentPart.AddNewPart<StyleDefinitionsPart>();
                }
                else
                {
                    styleDefn = doc.MainDocumentPart.StyleDefinitionsPart;
                }
            // populate part with the new styles
            if (styleDefn != null)
            {
                // write the newStyle xDoc to the StyleDefinitionsPart using a streamwriter
                newStyles.Save(new StreamWriter(
                               styleDefn.GetStream(FileMode.Create, FileAccess.Write)));
            }
            // probably not needed (works for me with or without this save)
            doc.Save();
        }
    }
