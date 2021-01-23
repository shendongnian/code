    public void PopulateInfoBase(InfoBase infoToPopulate, WhateverUserInputIs userInput)
    {
        infoToPopulate.sharedData1 = Process(userInput["data1"]);
        infoToPopulate.sharedData2 = ProcessDifferently(userInput["data2"] + userInput["AuxData"]);
        etc etc
    }
