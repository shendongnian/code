    var data = new
    {
        blocks = new object[] {
                new {
                    type = "section",
                    text = new {
                        type = "plain_text",
                        text = "Hello!",
                        emoji = true
                    }
                },
                new {
                    type = "divider"
                },
                new {
                    type = "actions",
                    elements = new object[] {
                        new {
                            type = "button",
                            text = new {
                                type = "plain_text",
                                text = "Help"
                            },
                            value = "helpButton"
                        }
                    }
                }
            }
    };
	
	return new JsonResult(data);
	
