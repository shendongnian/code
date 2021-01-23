    container.Register(
    	Component.For<IFormatter<string>().ImplementedBy<TextMessageFormatter>().Named("TextMessageFormatter"),
    	Component.For<IFormatter<string>().ImplementedBy<EmailFormatter>().Named("EmailFormatter"),
    	Component.For<INotificationService>().ImplementedBy<EmailNotificationService>().ServiceOverrrides(
    		ServiceOverride.ForKey("emailFormatter").Eq("EmailFormatter"))
    );
