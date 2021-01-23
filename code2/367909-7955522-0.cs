    FormCollection fc;
    public Email(FormCollection fc)
        {
            StringBuilder sb = new StringBuilder();
            this.fc = fc;
            string[] keys = fc.AllKeys;
            sb.Append("Category," + fc[keys[0]] + ",<br />");
            sb.Append("Type,"+ fc[keys[1]] +",<br />");
         }
