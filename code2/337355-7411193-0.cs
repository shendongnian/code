         bool doesNodeExist = false;
         foreach (XmlNode xNode in xNodes)
                        {
                            if (image.Equals("COMMON.BACKGROUND.PNG"))
                            {
                                if (xNode.Attributes[0].Value == "COMMON.BACKGROUND.PNG")
                                {
    doesNodeExist = true;
                                    xNode.FirstChild.Attributes[0].Value = text1;
                                    xXMLTVDoc.Save(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + (@"\Media Center Themer") + @"\MCTDefault.xml");
                                    break;
                                }
                            }
                       }
           if(!doesNodeExist)
          {
              //Create Logic here...
          }
