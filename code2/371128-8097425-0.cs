            protected void RemoveMobileLayout(Item item)
        {
            using (new SecurityDisabler())
            {
                LayoutDefinition layoutDefinition = Sitecore.Layouts.LayoutDefinition.Parse(item[Sitecore.FieldIDs.LayoutField]);
                DeviceDefinition mobileDevice = layoutDefinition.GetDevice(Resources.mobileDeviceID);
                if (mobileDevice.Layout != null) mobileDevice.Layout = null;
                if (mobileDevice.Renderings != null) mobileDevice.Renderings = null;
                item.Editing.BeginEdit();
                item[Sitecore.FieldIDs.LayoutField] = layoutDefinition.ToXml();
                item.Editing.EndEdit();
            }
        }
        protected void AddMobileLayout(Item item)
        {
            using (new SecurityDisabler())
            {
                LayoutDefinition layoutDefinition = Sitecore.Layouts.LayoutDefinition.Parse(item[Sitecore.FieldIDs.LayoutField]);
                DeviceDefinition mobileDevice = layoutDefinition.GetDevice(Resources.mobileDeviceID);
                TemplateItem itemTemplate = item.Template;
                if (itemTemplate != null)
                {
                    if (itemTemplate.StandardValues != null)
                    {
                        Item standardValues = itemTemplate.StandardValues;
                        foreach (DeviceItem deviceItem in Sitecore.Configuration.Factory.GetDatabase("master").Resources.Devices.GetAll())
                        {
                            if (deviceItem.ID.ToString() == Resources.mobileDeviceID)
                            {
                                mobileDevice.Layout = standardValues.Visualization.GetLayout(deviceItem).ID.ToString();
                                RenderingReference[] sublayouts = standardValues.Visualization.GetRenderings(deviceItem, true);
                                foreach (RenderingReference sublayout in sublayouts) mobileDevice.AddRendering(new RenderingDefinition() { ItemID = sublayout.RenderingItem.ID.ToString(), Placeholder = sublayout.RenderingItem.Placeholder });
                            }
                        }
                    }
                }
                item.Editing.BeginEdit();
                item[Sitecore.FieldIDs.LayoutField] = layoutDefinition.ToXml();
                item.Editing.EndEdit();
            }
        }
