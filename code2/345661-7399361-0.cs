            XDocument currentPermission = XDocument.Parse(xmlParentStr);
            XDocument newPermission = XDocument.Load(xmlToAddStr);
            int fyValue = 2012, countryId = 205, stateId = 0, cityId = 0;
            //check whether user has access for this fiscal year or not
            IEnumerable<XElement> fyList = from fyNode in currentPermission.Descendants("FiscalYear")
                                           where (int)fyNode.Attribute("Name") == fyValue
                                           select fyNode;
            if (null != fyList && fyList.Count() > 0) //Fiscal year present, means user is trying to modify permissions for the given fiscal year
            {
                //Check whether user has access for this country or not
                IEnumerable<XElement> countryList = from subNode in fyList.Descendants("Country")
                                                       where (int)subNode.Attribute("ID") == countryId
                                                       select subNode;
                if (null != countryList && countryList.Count() > 0) //country present, means user is trying to modify permissions for a country
                {
                    IEnumerable<XElement> stateList = from mbpNode in countryList.Descendants("State")
                                                         where (int)mbpNode.Attribute("ID") == stateId
                                                         select mbpNode;
                    if (stateId != 0 && null != stateList && stateList.Count() > 0)
                    {
                        IEnumerable<XElement> cityList = from mbpNode in stateList.Descendants("City")
                                                                where (int)mbpNode.Attribute("ID") == stateId
                                                                select mbpNode;
                        if (cityId != 0 && null != cityList && cityList.Count() > 0)
                        {
                            // User already have access, nothing to do
                        }
                        else
                        {
                           
                            currentPermission.Elements("FiscalYear")
                            .Where(t => t.Attribute("Name").Value == fyValue.ToString())
                            .Elements("Country")
                            .Where(t => t.Attribute("ID").Value == countryId.ToString())
                            .Elements("State")
                            .Where(t => t.Attribute("ID").Value == stateId.ToString())
                            .Single()
                            .Add(newPermission.Descendants("City"));
                        }
                    }
                    else
                    {
                        
                        currentPermission.Elements("FiscalYear")
                        .Where(t => t.Attribute("Name").Value == fyValue.ToString())
                        .Elements("Country")
                        .Where(t => t.Attribute("ID").Value == countryId.ToString())
                        .Single()
                        .Add(newPermission.Descendants("State"));
                    }
                }
                else //Country is not present means user is granted permissions for this country
                {
                    currentPermission.Elements("FiscalYear")
                        .Where(t => t.Attribute("Name").Value == fyValue.ToString())
                        .Single()
                        .Add(newPermission.Descendants("Country"));
                }
            }
            else //fiscal year is not present, it means user is trying to add permissions for a new fiscal year
            {
                //string newPermissionXML = CreatePermissionXML(newUserPermission);
                currentPermission.Add(newPermission.Descendants("FiscalYear"));
            }
