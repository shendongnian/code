    builder.OwnsOne(x => x.Client, client =>
    {
        client.Property(x => x.Id).IsRequired(false);
        client.Property(x => x.Name).IsRequired(false);
        client.HasIndex(x => x.Id); // <--
    });
