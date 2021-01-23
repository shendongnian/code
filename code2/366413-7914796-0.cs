    private void SchemaValidationEventHandler(object sender, ValidationEventArgs e) {
        Console.WriteLine("XML {0}: {1} (Line {2})",
                             e.Severity,
                             e.Message,
                             e.Exception.LineNumber);
    }
