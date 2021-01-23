    var elements = from element in doc.Descendants("Question")
                   select new
                   {
                       Id = element.Element("Id"),
                       Text = element.Element("Text"),
                       Reserver = element.Element("Reserver")
                   };
    StringBuilder builder = new StringBuilder();
    foreach (var question in elements)
    {
        // Read
        builder.AppendLine(question.Id.Value + "-" + question.Text.Value);
        // Write
        question.Reserver.Value = "True";
    }
    myTextBox.Text = builder.ToString();
