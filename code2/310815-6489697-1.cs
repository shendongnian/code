         protected void lbtnNext_Click(object sender,EventArgs e)
         {
              TextBox txt = ((TextBox)pnlQuestions.FindControl("que1"));
              AnswerText = txt.Text.Trim();
              Response.Write(AnswerText); 
         }
