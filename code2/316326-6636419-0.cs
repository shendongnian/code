            public static void ExtractRules(Type targetType , string ruleSet) {
            var settings = (ValidationSettings)ConfigurationManager.GetSection ( ValidationSettings.SectionName );
            if ( settings != null ) {
                var type = settings.Types.Where ( t => t.Name == targetType.FullName ).FirstOrDefault ( );
                if ( type != null ) {
                    var data = type.Rulesets.Where ( t => t.Name == ruleSet ).FirstOrDefault();
                    if ( data != null ) {
                        List<ValidatorData> validatorDatas = new List<ValidatorData> ( );
                        data.Properties.ForEach ( (p) => {
                           validatorDatas.AddRange( p.Validators.Cast<ValidatorData> ( ));
                        } );
                        data.Fields.ForEach ( (f) => {
                            validatorDatas.AddRange ( f.Validators.Cast<ValidatorData> ( ) );
                        } );
                    }
                }
            }
        }
