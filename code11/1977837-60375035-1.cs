       public EcheqSubmissionStatusApi StatusDbToApi(EcheqSubmissionStatus dbStatus,        EcheqSubmissionBase EcheqSubmissionBase)
           {
               EcheqSubmissionStatusApi status;
        // EcheqSubmissionInfoApi echeqSubmissionInfoApi = new EcheqSubmissionInfoApi();
        if (EcheqSubmissionBase.ValidUntilUtc < DateTime.Now)
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
