    public static void Add_Event_To_Button_Import(Button btn, string Primary_Key_Text_Field)
    {
        btn.OnClientClick = "return Load_Import_Search_Invoice_No('" + Primary_Key_Text_Field + "');";
    }
    public static void Add_Event_To_Button_Import_commercial(Button btn, string Primary_Key_Text_Field)
    {
        btn.OnClientClick = "return Load_Import_Search_Commercial_Invoice_Form('" + Primary_Key_Text_Field + "');";
    }
    public static void Add_Event_To_Button_Import_commercial_PostShipment(Button btn, string Primary_Key_Text_Field)
    {
        btn.OnClientClick = "return Load_Import_Search_Commercial_Invoice_For_PostShipment('" + Primary_Key_Text_Field + "');";
    }
    //public static void Add_Event_To_Button_Import_Commercial_Invoice(Button btn, string Primary_Key_Text_Field)
    //{
    //    btn.OnClientClick = "return Load_imp_Search_Commercial_Invoice_No('" + Primary_Key_Text_Field + "');";
    //}
    //public static void Add_Event_To_Button_Import_Commercial_Invoice(Button btn, string Primary_Key_Text_Field)
    //{
    //    btn.OnClientClick = "return Load_imp_Search_Commercial_Invoice_No('" + Primary_Key_Text_Field + "');";
    //}
    public static void Add_Event_To_Button_Import_Commercial_Invoice(Button btn, string Primary_Key_Text_Field)
    {
        btn.OnClientClick = "return Load_Import_Search_Commercial_Invoice_Form('" + Primary_Key_Text_Field + "');";
    }
