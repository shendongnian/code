            using (var context = new MyEntities())
            {
                string lastSectionHeading = "";
                bool isFirstHeading = true;
                var dynamicPageItems = context.view_dynamicPageItems;
                foreach (var item in dynamicPageItems)
                {
                    if (item.IsActive == 1)
                    {
                        if (!lastSectionHeading.Equals(item.CategoryId))
                        {
                            if (!isFirstHeading)
                                CloseSection();
                            lastSectionHeading = item.CategoryId;
                            AddSettingsSection(item.CategoryDescription);
                            isFirstHeading = false;
                        }
                        AddControl( item.DataType );
                    }
                }
            }
