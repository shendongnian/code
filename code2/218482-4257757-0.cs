    MyTestContext testcontext = new MyTestContext();
    string tname =  savetdlg.TNameTBox.Text;
    
    testcontext.CheckRec(tname, x => context_CheckRecCompleted(x), null);
    void context_CheckRecCompleted(InvokeOperation<bool> op)
        {
            bool notunique = op.Value;
            if (notunique == true)
            {
                //todo if record exists
            }
            else
            {
                //todo if record doesn't exist
            }
        }
