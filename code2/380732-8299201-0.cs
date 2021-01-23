    MembershipUser membershipUser = Membership.GetUser();
    if(null != membershipUser)
    {
        int userId;
    	if(int.TryParse(membershipUser.ProviderUserKey.ToString(), out userId)
    	{
    		int testRet = sendData.InsertQuestionnaire(QuestionnaireName.Text, userId, Int32.Parse(NumberOfQuest.Text));
    		Session["QuestionnaireID"] = testRet;
    		Session["QuestionnaireName"] = QuestionnaireName.Text;
    		Response.Redirect("~/buildq/add_questions.aspx");
    	}
    
    }else
    {
    	// user may not login , redirrect to login page
    }
