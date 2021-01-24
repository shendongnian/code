    //Ling to Mock
    IAppSettingLogic MoqAsl = Mock.Of<IAppSettingLogic>(asl => asl.SimpleMember == someSimpleValue);
    //Add traditional setup to get access to return function using "Mock.Get(T)"
    Mock.Get(MoqAsl)
        .Setup(_ => _.SetAppSettingAsync(AppSettings.LatestReconciliationValue, It.IsAny<string>(), It.IsAny<string>())
        .Returns( (string arg0, string val, string args3) => {
            UpdatedValue = val;
            return Task.CompletedTask;
        });
