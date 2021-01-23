    public class WhateverFactory : IWhateverFactory {
         public IWhatever GetWhatever(string parameter) {
             if(parameter == "value for other whatever")
                return new OtherWhatever();
             return new DefaultWhatever();
         }
    }
