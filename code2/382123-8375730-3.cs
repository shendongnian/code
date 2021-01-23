    OpenXmlPart part = doc.MainDocumentPart.GetPartById(ctrl.Id);
    OpenXmlReader re = OpenXmlReader.Create(part.GetStream());
    re.Read();
    OpenXmlElement el = re.LoadCurrentElement();          
    if(el.GetAttribute("classid", el.NamespaceUri).Value == "{8BD21D40-EC42-11CE-9E0D-00AA006002F3}")
    {
      Console.WriteLine("Checkbox found...");
    }
    re.Close();
