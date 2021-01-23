     private string getGPOLinkCount(string OUPathDN, bool onlyEnabledLinks, bool includeInheritedLinks)
        {
            int linkCount = 0;
            try
            {
                GPMGMTLib.GPM gpm = new GPMGMTLib.GPM();
                GPMGMTLib.IGPMConstants gpc = gpm.GetConstants();
                GPMGMTLib.IGPMDomain gpd = gpm.GetDomain(Environment.GetEnvironmentVariable("USERDNSDOMAIN"), "", gpc.UseAnyDC);
                GPMGMTLib.GPMSOM gpSom = gpd.GetSOM(OUPathDN);
                GPMGPOLinksCollection GPOLinks = gpSom.GetGPOLinks();
                GPMGPOLinksCollection GPOLinksIncludingInherited = gpSom.GetInheritedGPOLinks();
                             
                if (!includeInheritedLinks)
                {
                    foreach (GPMGPOLink GPOLink in GPOLinks)
                    {
                        if (onlyEnabledLinks)
                        {
                            if (GPOLink.Enabled)
                            {
                                linkCount++;
                            }
                        }
                        if (!onlyEnabledLinks) //Get all links, disabled or enabled
                        {
                            linkCount++;
                        }
                    }                   
                }
                if (includeInheritedLinks)
                {
                    foreach (GPMGPOLink GPOLink in GPOLinksIncludingInherited)
                    {
                        if (onlyEnabledLinks)
                        {
                            if (GPOLink.Enabled)
                            {
                                linkCount++;
                            }
                        }
                        if (!onlyEnabledLinks) //Get all links, disabled or enabled
                        {
                            linkCount++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return "GPO links: " + ex.Message.Replace("\r\n", "");
            }
            return linkCount.ToString();            
        }
