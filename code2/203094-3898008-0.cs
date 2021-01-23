    public static IEnumerable<MembershipModule> GetAccesible()
    {
        // Skip unnecessary querying
        if(!MembershipUser.Connected)
            return LinqUtil.Context.MembershipModules.Where(m => m.Enabled && m.OfflineAccess).ToList();
        // Accessible modules
        var modules =
            from m in LinqUtil.Context.MembershipModules
            where m.IsAccessible()
            select m;
        return modules.ToList();
    }
