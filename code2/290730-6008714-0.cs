            for (int i = 0; i < 9; i++)
            {
                OleDbParameter op = new OleDbParameter("OP", OleDbType.VarChar, 50);
                op.Value = textBoxControlArray[i].Text;
                myAccessCommand.Parameters.Add(op);
            }
