     foreach (Type T in DialogControlRegistrationService.RegisteredTypes)
                {
                    Type genericType = typeof(DialogControlService<>).MakeGenericType(new Type[] { T });
                    var property = genericType.GetProperty("DesiredDialogResult",
                        BindingFlags.Static | BindingFlags.Public);
                    property.SetValue(genericType, DialogResult.None);
                    property = genericType.GetProperty("Attribute",
                        BindingFlags.Static | BindingFlags.Public);
                    property.SetValue(genericType, null);
                }
                DialogControlRegistrationService.RegisteredTypes.Clear();
