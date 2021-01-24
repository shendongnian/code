    var UpdateValue = string.Empty;
    var mock = new Mock<IAppSettingLogic>();
    mock
        .Setup(_ => _.SetAppSettingAsync(AppSettings.LatestReconciliationValue, It.IsAny<string>(), It.IsAny<string>())
        .Returns( (string arg0, string val, string args3) => {
            UpdatedValue = val;
            return Task.CompletedTask;
        });
    IAppSettingLogic MoqAsl = mock.Object;
