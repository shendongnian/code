    private Dictionary<string, string> GetEntities(XmlReader xr)
    {
        Dictionary<string, string> entityList = new Dictionary<string, string>();
        while (xr.Read())
        {
            HandleNode(xr, entityList);
        }
        return entityList;
    }
    StringBuilder sbEntityResolver;
    int extElementIndex = 0;
    int resolveEntityNestLevel = -1;
    string dtdCurrentTopEntity = "";
    private void HandleNode(XmlReader inReader, Dictionary<string, string> entityList)
    {
        if (inReader.NodeType == XmlNodeType.Element)
        {
            if (resolveEntityNestLevel < 0)
            {
                    while (inReader.MoveToNextAttribute())
                    {
                        HandleNode(inReader, entityList); // for namespaces
                        while (inReader.ReadAttributeValue())
                        {
                            HandleNode(inReader, entityList); // recursive for resolving entity refs in attributes
                        }                       
                    }
            }
            else
            {
                extElementIndex++;
                sbEntityResolver.Append(inReader.ReadOuterXml());
                resolveEntityNestLevel--;
                if (!entityList.ContainsKey(dtdCurrentTopEntity))
                {
                    entityList.Add(dtdCurrentTopEntity, sbEntityResolver.ToString());
                }
            }
        }
        else if (inReader.NodeType == XmlNodeType.EntityReference)
        {
            if (inReader.Name[0] != '#' && !entityList.ContainsKey(inReader.Name))
            {
                if (resolveEntityNestLevel < 0)
                {
                    sbEntityResolver = new StringBuilder(); // start building entity
                    dtdCurrentTopEntity = inReader.Name;
                }
                // entityReference can have contents that contains other
                // entityReferences, so keep track of nest level
                resolveEntityNestLevel++;
                inReader.ResolveEntity();
            }
        }
        else if (inReader.NodeType == XmlNodeType.EndEntity)
        {
            resolveEntityNestLevel--;
            if (resolveEntityNestLevel < 0)
            {
                if (!entityList.ContainsKey(dtdCurrentTopEntity))
                {
                    entityList.Add(dtdCurrentTopEntity, sbEntityResolver.ToString());
                }
            }
        }
        else if (inReader.NodeType == XmlNodeType.Text)
        {
            if (resolveEntityNestLevel > -1)
            {
                sbEntityResolver.Append(inReader.Value);
            }
        }
    }
