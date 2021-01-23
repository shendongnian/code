    List<BI_QA_ChoiceEntity> choiceSet = new List<BI_QA_ChoiceEntity>();
    choiceSet = biEntityObj.ChoiceSet;
    XmlDocument ChoiceXML = new XmlDocument();
    ChoiceXML.AppendChild(ChoiceXML.CreateElement("CHOICESET"));
    foreach (var item in choiceSet)
    {
        XmlElement element = ChoiceXML.CreateElement("CHOICE");
        // element.AppendChild(ChoiceXML.CreateElement("CHOICE_ID")).InnerText = Convert.ToString(item.ChoiceID);
        element.AppendChild(ChoiceXML.CreateElement("CHOICE_TEXT")).InnerText = Convert.ToString(item.ChoiceText);
        element.AppendChild(ChoiceXML.CreateElement("SEQUENCE")).InnerText = Convert.ToString(item.Sequence);
        element.AppendChild(ChoiceXML.CreateElement("ISCORRECT")).InnerText = Convert.ToString(item.IsCorrect);
        ChoiceXML.DocumentElement.AppendChild(element);
    }
