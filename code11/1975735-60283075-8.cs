    internal interface IUsuairoSistemaCompatibleForm 
    {
        string user { get; set; }
        int loginID { get; set; }
        LoginInfo loginInfo { get; set; }
        string Text { get; set; }
        void Show();
    }
