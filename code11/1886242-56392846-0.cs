        if (bmtProp->fIsHardwareIntrinsic || (S_OK == GetCustomAttribute(pMethod->GetMethodSignature().GetToken(),
                                                    WellKnownAttribute::Intrinsic,
                                                    NULL,
                                                    NULL)))
        {
            pNewMD->SetIsJitIntrinsic();
        }          
