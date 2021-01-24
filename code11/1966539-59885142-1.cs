    [BeforeScenario("upgrade")]
            public void BeforeScenarioUpgradeFalseorTrue()
            {
                if (BindingClass._scenarioContext.ScenarioInfo.Tags.Contains("false"))
                {
                    log.Info("upgrade is false..");
                }
                     
                if (BindingClass._scenarioContext.ScenarioInfo.Tags.Contains("true"))
                {
                    log.Info("upgrade is true..");
                }
            }
