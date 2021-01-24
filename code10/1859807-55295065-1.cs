        // Set the verification level
        //
        var burnVerification = (IBurnVerification)discFormatData;
        burnVerification.BurnVerificationLevel = _verificationLevel;
>        //
        // Check if media is blank, (for RW media)
        //
        object[] multisessionInterfaces = null;
        if (!discFormatData.MediaHeuristicallyBlank)
        {
            multisessionInterfaces = discFormatData.MultisessionInterfaces;
        }
