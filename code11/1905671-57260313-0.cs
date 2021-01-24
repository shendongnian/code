    BYDUpdateTimeSvc.EmployeeTimeCreateRequestMessage_sync req = new BYDUpdateTimeSvc.EmployeeTimeCreateRequestMessage_sync()
    {
        BasicMessageHeader = new BYDUpdateTimeSvc.BusinessDocumentBasicMessageHeader(),
        EmployeeTime = new BYDUpdateTimeSvc.EmployeeTimeCreateRequest()
        {
            EmployeeTimeAgreementItemUUID = new BYDUpdateTimeSvc.UUID { Value = rec.employeeTimeAgreement },
            Item = new BYDUpdateTimeSvc.EmployeeTimeCreateRequestItem[1]
            {
                new BYDUpdateTimeSvc.EmployeeTimeCreateRequestItem()
                {
                    TypeCode = activityCode,
                    PaymentTypeCode = locationCode,
                    EmployeeTimeValidity = _dateValidity
                }, // added comma
                ActionCode = "02"; // set action code here
            }            
        }
    };
