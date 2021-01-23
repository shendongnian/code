	foreach (var GroupType in typeof(MainGroup).GetFields())
	{
		object Group = GroupType.GetValue(NewMainGroup);
		Response.Write("<BR>MainGroupName=  " + GroupType.Name + " Value=  " + Group.ToString());
		foreach(var SubGroupType in Group.GetType().GetFields()) {
			object SubGroup = SubGroupType.GetValue(Group);
			Response.Write("<BR>SubGroupName= " + SubGroupType.Name + " Value= " + SubGroup.ToString());
		}
	}
