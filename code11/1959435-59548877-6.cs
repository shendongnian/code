    var botCommands = typeof(IBotCommand)
                        .ImplementingTypes()
                        .Select(t => new { Type = t, attrib = t.GetTypeInfo().GetCustomAttribute<CommandAttribute>(false) })
                        .Select(ta => new {
                            ta.Type,
                            TriggerString = ta.attrib.TriggerString
                        })
                        .ToDictionary(tct => tct.TriggerString, tct => tct.Type);
