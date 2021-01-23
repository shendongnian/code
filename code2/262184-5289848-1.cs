    var doc = XDocument.Load (Server.MapPath(".") + "\\Questions.config");
    var elements = from element in doc.Descendants("Question")
                   select new
                   {
                       Id = element.Element("Id").Value,
                       Text = element.Element("Text").Value,
                       Reserver = element.Element("Reserver") != null
                   };
    StringBuilder builder = new StringBuilder();
    foreach (var question in elements)
    {
        builder.AppendLine(question.Id + "-" + question.Text);
    }
    myTextBox.Text = builder.ToString();
