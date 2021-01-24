    public static bool UpdateMember(string name, string lastname, string ismanager, string birthday, string positionID, string memberID)
    {
        return Update(new NameValueCollection()
        {
            {"update_Member","1" },
            {"Name", name },
            {"LastName", lastname },
            {"isManager", ismanager },
            {"Birthday", birthday },
            {"PositionID", positionID},
            {"MemberID", memberID }
        });
    }
    public static bool UploadPosition(string PosName)
    {
        return Update(new NameValueCollection()
        {
            {"add_Position","1" },
            {"PosName",PosName }
        });
    }
