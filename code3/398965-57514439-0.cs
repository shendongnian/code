    doc.Validate(schemas, (sender, args) =>
    {
        var lineInfo = sender as IXmlLineInfo;
        validationErrors.Add(String.Format("{0}: {1} [Ln {2} Col {3}]",
            args.Severity,
            args.Exception.Message,
            lineInfo?.LineNumber,
            lineInfo?.LinePosition));
        isValid = false;
    }, false);
