            CustomMembershipProvider provider = new CustomMembershipProvider();
            // original method
            provider.ValidateUser("un", "pass"); 
            // or call our new overload
            provider.ValidateUser("un", "pass", LoginValidationType.WebsiteSpecific); 
