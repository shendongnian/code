	object data = new
	{
		attachment = new
		{
			type = "template",
			payload = new
			{
				template_type = "generic",
				elements = new[]
				{
					new
					{
						title = "generic title",
						subtitle = "generic subtitle",
						image_url = "",
						buttons = new[]
						{
							new
							{
								type = "postback",
								title = "postback title",
								payload = "postback payload"
							}
						}
					}
				}
			}
		}
	};
