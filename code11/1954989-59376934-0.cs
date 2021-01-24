    Thanks to Mohit, this is the solution I found.
    
    var claimsIdentity = (System.Security.Claims.ClaimsIdentity)User.Identity;
       
     List<String> termsList = new List<String>();
        foreach (var claim in claimsIdentity.Claims)
        {
            termsList.Add(claim.Value);
        }
       //The 2nd item in the claim is the objectidentifier
        Debug.WriteLine(termsList[2]); 
    // there is probably a cleaner way, but it works for me. 
