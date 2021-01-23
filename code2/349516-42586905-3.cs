	public const string XEntry = "ifXEntry";
	public static readonly dynamic XEntryItems = new Dictionary<string, object>
	{
		{ "Name",                     XEntry + ".1" },
		{ "InMulticastPkts",          XEntry + ".2" },
		{ "InBroadcastPkts",          XEntry + ".3" },
		{ "OutMulticastPkts",         XEntry + ".4" },
		{ "OutBroadcastPkts",         XEntry + ".5" },
		{ "HCInOctets",               XEntry + ".6" },
		{ "HCInUcastPkts",            XEntry + ".7" },
		{ "HCInMulticastPkts",        XEntry + ".8" },
		{ "HCInBroadcastPkts",        XEntry + ".9" },
		{ "HCOutOctets",              XEntry + ".10" },
		{ "HCOutUcastPkts",           XEntry + ".11" },
		{ "HCOutMulticastPkts",       XEntry + ".12" },
		{ "HCOutBroadcastPkts",       XEntry + ".13" },
		{ "LinkUpDownTrapEnable",     XEntry + ".14" },
		{ "HighSpeed",                XEntry + ".15" },
		{ "PromiscuousMode",          XEntry + ".16" },
		{ "ConnectorPresent",         XEntry + ".17" },
		{ "Alias",                    XEntry + ".18" },
		{ "CounterDiscontinuityTime", XEntry + ".19" },
	}.ToExpando();
