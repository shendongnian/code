    var jsoninput = new LinkInParams(new LastByShiftParams(apiKey, "01/21/2020", "01/29/2020"));
        
        
             public LinkInParams(object inObject)
                    {
                        inputParams = JsonConvert.SerializeObject(inObject, Formatting.Indented);
                    }  
        
          class LastByShiftParams
            {  
         public string SecurityCode ;
                public string StatusID ;
                public string FromShiftDate ;
                public string ToshiftDate ;
                public bool ExcludePerDiem ;
                public bool ExcludeContracts ;
                public bool ExcludePermPlacement;
            }
