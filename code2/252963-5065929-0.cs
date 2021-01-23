    public void xmlsection(XmlSection Section)
    {
        cont.ContentControls.Add(new Separator(xml.Sections[section].Name));
        foreach (var variable in xml.Sections[section].Variables)
        {
            TraverseVars(cont, xml.Sections[section].Name, variable.Value.Name, variable.Value.Title, variable.Value.Default1, variable.Value.Default2, variable.Value.Default3, variable.Value.DesignerType);
            i++;
        }
        if (xml.Sections[section].Sections.Count > 0)
        {
            foreach (var section2 in xml.Sections[section].Sections.Keys)
            {
    xmlsection(section2);
            }
        }
    
    }
