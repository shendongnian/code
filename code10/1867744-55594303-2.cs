    Rules.AddConditional<LoginOptions>(
        new ConditionalRule<ConnectionSettingsViewModel, LoginOptions>(
            nameof(Username),
            "Username: Cannot be empty, starting with a space or a backslash.",
            x => !string.IsNullOrWhiteSpace(x.Username),
            LoginOptions.Instrument
        )
    );
