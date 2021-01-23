    public static class Find_Feature
    {   
    #region Export 
        public static void Add_Event_To_Button(Button btn, int Index, string Primary_Key_Text_Field)
        {
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
          
    #endregion
    #region Import
    
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
    #endregion  
    #region Textbox Events
        public static void Add_Event_To_TextBox(TextBox txt, int Index, string Primary_Key_Text_Field, string Next_To_Focus_Control)
        {
            txt.Attributes.Add("onfocus", "return Load_Search_Form('" + Index + "','" + Primary_Key_Text_Field + "','"
                + Next_To_Focus_Control + "')");
        }
        public static void Add_Event_To_TextBox(string tablename, TextBox txt, string Primary_Key_Text_Field, string Next_To_Focus_Control, string ID_Column, string Display_Field1, string Display_Field2, string ConditionField, string Opr, string value_field)
        {
            txt.Attributes.Add("onfocus", "return Load_Search_Form_byEmployee('" + tablename + "','" + Primary_Key_Text_Field + "','" + Next_To_Focus_Control +
                "','" + ID_Column + "','" + Display_Field1 + "','" + Display_Field2 + "','" + ConditionField + "','" + Opr + "','" + value_field + "')");
        }
     public static void Add_Event_To_Button(string tablename, Button btn, string Primary_Key_Text_Field, string ID_Column, string Display_Field1, string Display_Field2, string ConditionField, string Opr, string value_field)
        {
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
