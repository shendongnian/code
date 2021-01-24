	public void AddSingleUser(string email, string role, string [] fleets)
	{
		_regRep.btnAddUser.Click();
		objCommon.EnterText(_regRep.firstNameAdd, userName);
		objCommon.EnterText(_regRep.lastNameAdd, "Smithy");
		objCommon.EnterText(_regRep.userEmailAdd, email);
		objCommon.EnterText(_regRep.userTelephoneAdd, "12345678901");
		objCommon.Exists(_regRep.userRoleManager(role), 10);
		objCommon.ScrollInToViewAndClick(_regRep.userRoleManager(role));
		foreach (string fleet in fleets)
		{
		    if (fleet != "")
			{
				objCommon.Exists(_regRep.chooseFleet(fleet), 5);
				objCommon.ScrollInToViewAndClick(_regRep.chooseFleet(fleet));
			}
		}
		System.Threading.Thread.Sleep(2000);
		objCommon.ScrollInToViewAndClick(_regRep.btnSaveUser);
		WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
		wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[text() = 'User created.']")));
	}
