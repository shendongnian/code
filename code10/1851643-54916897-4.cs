    BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Instance;
    var propGrid = propertyGrid1.Controls.OfType<Control>()
                                .Where(ctl => ctl.AccessibilityObject.Role == AccessibleRole.Table).First();
    var totalProperties = (int)propGrid.GetType().GetField("totalProps", flags).GetValue(propGrid);
    var vScroll = propertyGrid1.Controls.OfType<Control>()
                               .Where(ctl => ctl.AccessibilityObject.Role == AccessibleRole.Table)
                               .First().Controls.OfType<VScrollBar>().First();
    var vRelativeScroll = vScroll.Value / (float)totalProperties;
    propertyGrid1.SelectedObject = [Some Other Object];
    totalProperties = (int)propGrid.GetType().GetField("totalProps", flags).GetValue(propGrid);
    vScroll.Value = (int)(vRelativeScroll * totalProperties);
