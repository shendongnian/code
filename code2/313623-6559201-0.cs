    public static class FormExtentsions
    {
        public static void SetDefault(this Form form)
        {
            form.Icon = new Icon("path");
            form.StartPosition = FormStartPosition.CenterScreen;
        }
    }
    
