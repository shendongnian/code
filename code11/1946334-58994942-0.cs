            XDocument doc = XDocument.Parse(xmlString);
            doc.Validate(schemaSet, (o, e) =>
            {
                var elem = o as XElement;
                if(elem != null && elem.Name.LocalName.Equals("email"))
                {
                    var regex = @"([\w\-\.]+)@(([\w]+\.)+)([a-zA-Z]{2,15})";
                    var match = Regex.Match(elem.Value, regex, RegexOptions.IgnoreCase);
                    if (!match.Success)
                    {
                        validationErrors.Add(e.Message);
                    }
                }
                else
                {
                    validationErrors.Add(e.Message);
                }
            });
            if (validationErrors.Any())
            {
                throw new ValidationException(validationErrors.ToArray());
            }
