    private void updateBadgeGlyph()
     {​
         string badgeGlyphValue = "attention";​
     ​
         XmlDocument badgeXml = ​
             BadgeUpdateManager.GetTemplateContent(BadgeTemplateType.BadgeGlyph);​
     ​
         Windows.Data.Xml.Dom.XmlElement badgeElement = ​
             badgeXml.SelectSingleNode("/badge") as Windows.Data.Xml.Dom.XmlElement;​
         badgeElement.SetAttribute("value", badgeGlyphValue);​
     ​
         BadgeNotification badge = new BadgeNotification(badgeXml);​
     ​
         BadgeUpdater badgeUpdater = ​
             BadgeUpdateManager.CreateBadgeUpdaterForApplication();​
     ​
         badgeUpdater.Update(badge);​
     ​
     }
