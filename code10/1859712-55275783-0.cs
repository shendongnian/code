    var groupedItems = res.GroupBy(re => re => new
    // KeySelector: what should the elements of a group have in common
    // = make groups of Res with same RateCardId, RateCardName, ..., MdmChannelCallLetters
    {
         Id = re.RateCardId,
         Name = re.RateCardName,
         Description = re.RateCardDescription,
         ...
         MdmChannel = re.MdmChannelCallLetters,
    },
    // ResultSelector: take the Key (= what do they have in common,
    // and all Res that have these values for key
    // to make one new object:
    (key, resWithThisKey) => new
    {
        RateCardId = key.Id,
        RateCardName = key.Name,
        ...
        MdmChannelCallLetters = key.MdmChannel,
        // You want to concatenate the user names:
        UserNames = String.Join(',', resWithThisKey.Select(re => re.UserName)),
    });
