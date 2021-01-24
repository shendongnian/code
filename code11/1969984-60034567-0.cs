if (await _urlService.AccessCodeInUrlExistsAsync(returnUrl))
{
	string accessCode = await _urlService.GetAccessCodeFromUrlAsync(returnUrl);
could be taken out.
Also , `User?.Identity.IsAuthenticated` could be stored in variable and it would reduce one `if` hopefully:
    var userAuthenticated = User?.Identity.IsAuthenticated ?? false;
	// This call exists in both branches of if, thus we could take it out.
	var accessCodeInUrExists = await _urlService.AccessCodeInUrlExistsAsync(returnUrl);
	
	string accessCode = accessCodeInUrExists ? await _urlService.GetAccessCodeFromUrlAsync(returnUrl) : null;
	
	if ( userAuthenticated && accessCode != null)
	{
		var accessCodeVerification = await _authService.AccessCodeBelongsToAuthenticatedUserAsync(accessCode);
		
		if(accessCodeVerification)
			return RedirectToAction("Index");
			
		await _authService.LogoutAsync(accessCode);
        return RedirectToAction("GetAccessCode");
	}
	else if( accessCode != null)
	{
		await _authService.LoginAsync(accessCode);
		return RedirectToAction("Index");
	}
	else
	{
		return RedirectToAction("GetAccessCode");
	}
	
Please, bear in mind, that I just did that for presentation purporse and you need to carefully test, if this works as desired.
I managed to reduce number of conditional instructions and hopefully made the code more readable with simple if statements.
