    // DateTimeOffsetField.cs
    public class DateTimeOffsetField : BoundField
    {
        private TimeSpan userOffsetTimeSpan;
        protected override DataControlField CreateField()
        {
            return new DateTimeOffsetField();
        }
        protected override void CopyProperties(DataControlField newField)
        {
            base.CopyProperties(newField);
            ((DateTimeOffsetField)newField).userOffsetTimeSpan = userOffsetTimeSpan;
        }
        public override bool Initialize(bool sortingEnabled, System.Web.UI.Control control)
        {
            bool ret = base.Initialize(sortingEnabled, control);
            int timezoneOffset = ((Int32)HttpContext.Current.Profile.GetPropertyValue("TimezoneOffset")).ToRepresentativeInRange(-12, 24);
            userOffsetTimeSpan = new TimeSpan(-timezoneOffset, 0, 0);
            return ret;
        }
        protected override void OnDataBindField(object sender, EventArgs e)
        {
            base.OnDataBindField(sender, e);
            var target = (Control)sender;
            if (target is TableCell)
            {
                var tc = (TableCell)target;
                var dataItem = DataBinder.GetDataItem(target.NamingContainer);
                var dateTimeOffset = (DateTimeOffset)DataBinder.GetPropertyValue(dataItem, DataField);
                tc.Controls.Add(new TimeagoDateTimeOffset { DateTimeOffset = dateTimeOffset.ToOffset(userOffsetTimeSpan) });
            }
        }
    }
