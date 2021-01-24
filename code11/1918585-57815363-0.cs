            AmadeusPDT.AmadeusWebServicesPTClient c = new AmadeusPDT.AmadeusWebServicesPTClient();
            AmadeusPDT.Session thisSession = new AmadeusPDT.Session();
            AmadeusPDT.TransactionFlowLinkType flowType = new AmadeusPDT.TransactionFlowLinkType();
            AmadeusPDT.AMA_SecurityHostedUser aMA_SecurityHostedUser = new AmadeusPDT.AMA_SecurityHostedUser();
            AmadeusPDT.Fare_DisplayFaresForCityPairReply results = c.Fare_DisplayFaresForCityPair(ref thisSession,ref flowType,aMA_SecurityHostedUser,ap);
