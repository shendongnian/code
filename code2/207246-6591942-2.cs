        txt.Attributes.Add("onfocus", "return Load_Search_Form('" + Index + "','" + Primary_Key_Text_Field + "','"
            + Next_To_Focus_Control + "')");
    }
    public static void Add_Event_To_TextBox(string tablename, TextBox txt, string Primary_Key_Text_Field, string Next_To_Focus_Control, string ID_Column, string Display_Field1, string Display_Field2, string ConditionField, string Opr, string value_field)
    {
        txt.Attributes.Add("onfocus", "return Load_Search_Form_byEmployee('" + tablename + "','" + Primary_Key_Text_Field + "','" + Next_To_Focus_Control +
            "','" + ID_Column + "','" + Display_Field1 + "','" + Display_Field2 + "','" + ConditionField + "','" + Opr + "','" + value_field + "')");
    }
