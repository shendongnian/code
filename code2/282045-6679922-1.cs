    protected void odsDepRt_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters[0] = RTCD;
    }
    protected void frmDepRt_ItemInserted(object sender, FormViewInsertedEventArgs e)
    {
        if (e.Exception != null)
        {
            lblErr.Text = ErrHandler.HandleDataErr(e.Exception.InnerException, "", false).ToString().Trim();
            e.ExceptionHandled = true;
            e.KeepInInsertMode = true;
        }
        else
        {
            IEnumerator ValEnum = e.Values.GetEnumerator();
            string[,] KeyValPair=new string[3,2];
            int i = 0;
            while(ValEnum.MoveNext()) //Till not finished do print
            {
                KeyValPair[i,0]=    ((DictionaryEntry)ValEnum.Current).Key.ToString();
                KeyValPair[i, 1] = ((DictionaryEntry)ValEnum.Current).Value.ToString();
                i++;
            }
            RTCD = KeyValPair[0, 1];            
        }            
    }
`
