            var hostSection = WebConfigurationManager.GetSection(HostSection.SectionName, "/Views") as HostSection;
            if (hostSection != null)
            {
                hostSection.FactoryType = "Type.Name, Assembly";
            }
