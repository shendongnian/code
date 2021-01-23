    public override CommandState QueryState(CommandContext context)
    {
        var item = context.Items[0];
        return item.Fields["Spotlight"].Value == "" ? CommandState.Hidden : base.QueryState(context);
    }
