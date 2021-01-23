    context.Response.Write(
		jsonSerializer.Serialize(
			new
			{
                query = "Li",
                suggestions = new[] { "Liberia", "Libyan Arab Jamahiriya", "Liechtenstein", "Lithuania" },
                data = new[] { "LR", "LY", "LI", "LT" }
			}
        )
	);
