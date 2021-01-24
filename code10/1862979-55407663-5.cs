    public void SetStyleToTarget(string targetFile, XDocument newStyles)
    {
        // open with write permissions
        using (var doc = WordprocessingDocument.Open(targetFile, true))
        {
            // delete any existing style part
            doc.MainDocumentPart.DeletePart(doc.MainDocumentPart.StyleDefinitionsPart);
            // add the style definition part
            var styleDefn = doc.MainDocumentPart.AddNewPart<StyleDefinitionsPart>();
            
            // save the empty style part to the document
            Styles root = new Styles();
            root.Save(styleDefn);
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
