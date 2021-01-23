    if ( !context.Profiles.Any( p => p.Userid == data.ID ) ) {
                profile = new CarSystem.Profile{
                    LastUpdatedDate      = data.LastUpdatedDate.LocalDateTime,
                    PropertyNames        = data.PropertyNames, 
                    PropertyValuesBinary = data.PropertyValuesBinary, 
                    PropertyValuesString = data.PropertyValuesString,
                    Userid               = data.ID
                    //add the next line to ensure there is a pk field
                    ID                   = Guid.NewGuid()
                };
