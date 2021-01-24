       public EcheqSubmissionStatusApi StatusDbToApi(EcheqSubmissionStatus dbStatus, EcheqSubmissionStatus echeqSubmissionStatus=null, EcheqSubmissionInfoApi echeqSubmissionInfoApi=null )
    {
        EcheqSubmissionStatusApi status;
        // EcheqSubmissionInfoApi echeqSubmissionInfoApi = new EcheqSubmissionInfoApi();
        var validuntil = echeqSubmissionStatus != null ? echeqSubmissionStatus.ValidUntilUtc : (echeqSubmissionInfoApi != null ? echeqSubmissionInfoApi.ValidUntilUtc : null);
        if (validuntil < DateTime.Now)
        {
            return EcheqSubmissionStatusApi.Expired;
        }
        else
        {
            switch (dbStatus)
            {
                case EcheqSubmissionStatus.New:
                    status = EcheqSubmissionStatusApi.New;
                    break;
                case EcheqSubmissionStatus.Active:
                    status = EcheqSubmissionStatusApi.Active;
                    break;
                case EcheqSubmissionStatus.Submitted:
                    status = EcheqSubmissionStatusApi.Submitted;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dbStatus), dbStatus, "Not a valid status enum");
            }
        }
        return status
    }
