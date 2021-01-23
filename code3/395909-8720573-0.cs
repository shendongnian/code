	public ApplicationHost() {
		ApplicationMode.UnitTesting = true; // set a flag on a global helper class to indicate what mode we're running in; this flag can be evaluated in the global.asax.cs code to skip code which shall not run when unit testing
		// first we need to tweak the configuration to successfully perform requests and initialization later
		AuthenticationSection authenticationSection = (AuthenticationSection)WebConfigurationManager.GetSection("system.web/authentication");
		ClearReadOnly(authenticationSection);
		authenticationSection.Mode = AuthenticationMode.None;
		AuthorizationSection authorizationSection = (AuthorizationSection)WebConfigurationManager.GetSection("system.web/authorization");
		ClearReadOnly(authorizationSection);
		AuthorizationRuleCollection authorizationRules = authorizationSection.Rules;
		ClearReadOnly(authorizationRules);
		authorizationRules.Clear();
		AuthorizationRule rule = new AuthorizationRule(AuthorizationRuleAction.Allow);
		rule.Users.Add("*");
		authorizationRules.Add(rule);
		// now we execute a bogus request to fully initialize the application
		ApplicationCatcher catcher = new ApplicationCatcher();
		HttpRuntime.ProcessRequest(new SimpleWorkerRequest("/404.axd", "", catcher));
		if (catcher.ApplicationInstance == null) {
			throw new InvalidOperationException("Initialization failed, could not get application type");
		}
		applicationType = catcher.ApplicationInstance.GetType().BaseType;
	}
