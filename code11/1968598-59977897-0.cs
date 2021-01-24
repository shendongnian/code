    CreateMap<CasePlan, CasePlanView>()
         .ConstructUsing((caseplan, b) => { 
              var client= a.PrimaryReferral.Client; 
              return new CasePlanView(){ 
                  ClientName= client.FullName,
                  ClientBirthDate= client.BirthDate //and so on
        }
        });
