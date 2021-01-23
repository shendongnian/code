        public static SelectList BusinessDayConventionList(bool includeUnadjusted)
        {
           var list = ListBuilder(
                BusinessDayConventionHelper.GetFriendlyName(BusinessDayConvention.Following),
                BusinessDayConventionHelper.GetFriendlyName(BusinessDayConvention.ModifiedFollowing),
                BusinessDayConventionHelper.GetFriendlyName(BusinessDayConvention.Preceding));
           if (includeUnadjusted)
           {
             list.Items.Add(BusinessDayConventionHelper.GetFriendlyName(BusinessDayConvention.Unadjusted))
           }
           return list.
        }
