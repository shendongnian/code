    var attachment = new
    {
        type = "template",
        payload = new
        {
            template_type = "generic",
            elements = new []
            {
                new {
                    title = "title",
                    image_url = "https://thechangreport.com/img/lightning.png",
                    subtitle = "subtitle",
                    buttons = new object[]
                    {
                        new {
                            type = "element_share",
                            share_contents = new {
                                attachment = new {
                                    type = "template",
                                    payload = new
                                    {
                                        template_type = "generic",
                                        elements = new []
                                        {
                                            new {
                                                title = "title 2",
                                                image_url = "https://thechangreport.com/img/lightning.png",
                                                subtitle = "subtitle 2",
                                                buttons = new object[]
                                                {
                                                    new {
                                                        type = "web_url",
                                                        url = "http://m.me/petershats?ref=invited_by_24601",
                                                        title = "Take Quiz"
                                                    },
                                                },
                                            },
                                        },
                                    },
                                }
                            },
                        },
                    },
                },
            },
        },
    };
    reply.ChannelData = JObject.FromObject(new { attachment });
