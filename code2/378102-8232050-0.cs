var dictionaries = new [] {
	new { WAP = "1", System = "1", Subsystem = "1"},
	new { WAP = "1", System = "2", Subsystem = "2"},
	new { WAP = "2", System = "1", Subsystem = "1"},
	new { WAP = "2", System = "1", Subsystem = "2"},
	new { WAP = "2", System = "3", Subsystem = "2"},
	new { WAP = "3", System = "2", Subsystem = "1"}
};
var query = 
	from d in dictionaries
	group d by d.WAP into wapGroup 
	select new { 
		WAP = wapGroup.Key,
		SystemGroup = 
			from s in wapGroup
			group s by s.System into systemGroup
			select new {
				System = systemGroup.Key,
				SubsystemGroup = 
					from s in systemGroup
					group s by s.Subsystem into subsystemGroup
					select	new {
						SubSystem = subsystemGroup.Key
					}
			}
	};
query.Dump();
