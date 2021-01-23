        btn.OnClientClick = "return Find_Window('" + Index + "','" + Primary_Key_Text_Field + "')";
    }
     
    public static void Add_Event_To_Button(Button btn, string Primary_Key_Text_Field)
    {
        btn.OnClientClick = "return Load_Search_Invoice_Form('" + Primary_Key_Text_Field + "');";
    }
    public static void Add_Event_To_Button(Button btn, string Primary_Key_Text_Field, int Index)
    {
        btn.OnClientClick = "return Load_Search_Commercial_Invoice_Form('" + Primary_Key_Text_Field + "');";
    }
    public static void Add_Event_To_Button_Post_Shipment(Button btn, string Primary_Key_Text_Field, int Index)
    {
        btn.OnClientClick = "return Load_Search_Commercial_Invoice__Post_Shipment_Form('" + Primary_Key_Text_Field + "');";
    }
    public static void Add_Event_To_Print_Button(Button btn, Panel print)
    {
        btn.OnClientClick = "return Print('" + print.ClientID  + "');";
    }
    public static void Add_Event_To_Print_Button_ForIE(Button btn, Panel print)
    {
        btn.OnClientClick = "return PrintIE('" + print.ClientID + "');";
    }
    public static void Add_Event_To_Button_Advance(Button btn, string Primary_Key_Text_Field)
    {
        btn.OnClientClick = "return Load_Search_Pre_Advanced_Master('" + Primary_Key_Text_Field + "');";
    }
    public static void Add_Event_To_Button_General_Packing_List_Combine(Button btn, string Primary_Key_Text_Field)
    {
        btn.OnClientClick = "return Load_Search_Packing_List('" + Primary_Key_Text_Field + "');";
    }
    public static void Add_Event_To_Button_Other_Packing_List_Combine(Button btn, string Primary_Key_Text_Field)
    {
        btn.OnClientClick = "return Load_Search_Packing_List_Other('" + Primary_Key_Text_Field + "');";
    }
    public static void Add_Event_To_Find_Company(Button btn, string Primary_Key_Text_Field, int Index)
    {
        btn.OnClientClick = "return Load_Company_List_Form('" + Primary_Key_Text_Field + "');";
    }
      
