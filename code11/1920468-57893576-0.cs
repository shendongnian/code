C#
  // Instead of modelMapper.AddMappings use this:
  cfg.AddInputStream(
    NHibernate.Mapping.Attributes.HbmSerializer.Default.Serialize(
       typeof(MyObject).Assembly));
    // Now you can use this configuration to build your SessionFactory...
`ModelMapper` class is needed and works only for Mapping ByCode (as namespace `NHibernate.Mapping.ByCode` suggests).
