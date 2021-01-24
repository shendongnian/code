    var finalResult = context.User
                  .Select(x => new UserModel() {
                      UserName = x.Name,
                      UserAddress = x.Address,
                      PreviousAddress = x.PAddress,
                      PhoneNumber = x.PhoneNumbers.Select(y => y.PersonalNumber),
                  });
    
    if (!String.IsNullOrWhiteSpace(search.UserName))
        finalResult = finalResult.Where(x => EF.Functions.Like(x.UserName, $"%{search.UserName}%"));
    
    if (search.UserNameFilter != "")
        finalResult = finalResult.Where(x => EF.Functions.Like(x.UserName, $"%{search.UserNameFilter}%"));
    
    if (search.PhoneNumberFilter != "")
        finalResult = finalResult.Where(x => EF.Functions.Like(x.PhoneNumber.FirstOrDefault(), $"%{search.PhoneNumberFilter}%"));
    
    if (search.PreviousAddressFilter != "")
        finalResult = finalResult.Where(x => EF.Functions.Like(x.PreviousAddress, $"%{search.PreviousAddressFilter}%"));
    
    if (search.UserAddressFilter != "")
        finalResult = finalResult.Where(x => EF.Functions.Like(x.UserAddress, $"%{search.UserAddressFilter}%"));
    
    return finalResult;
