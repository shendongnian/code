    catch (DirectoryServicesCOMException ex)
    {
        Regex reg = new Regex(@"^(.*data )(?<ecode>\d*)");
        if(reg.IsMatch(ex.ExtendedErrorMessage))
        {
            GroupCollection groups = reg.Match(ex.ExtendedErrorMessage).Groups;
            errorCode = groups["ecode"].Value;
        }
    }
