        btn.OnClientClick = "return Load_Search_Find_byEmployee('" + tablename + "','" + Primary_Key_Text_Field +
            "','" + ID_Column + "','" + Display_Field1 + "','" + Display_Field2 + "','" + ConditionField + "','" + Opr + "','" + value_field + "')";
    }
    #endregion
    public static void PostBack(Button btn)
    {
        btn.Attributes.Add("onclick", "__doPostBack();");
    }
    public static void Gratuity()
    {
    }
}
