public void FillGVAnswer(int QuestionID)
    {
        try
        {
          
            OBJClsQuestionAnswer = new ClsQuestionAnswer();
            DS = new DataSet();
            DS = OBJClsQuestionAnswer.GetAnswers(QuestionID);
            GVAnswer.DataSource = DS.Tables[0];
            GVAnswer.DataBind();
            if (DS.Tables[0].Rows.Count > 0)
            {
                
                for (int i = 0; i < GVAnswer.Rows.Count; i++)
                {
                    GVAnswer.HeaderRow.Cells[2].Visible = false;
                    GVAnswer.HeaderRow.Cells[3].Visible = false;
                    GVAnswer.HeaderRow.Cells[6].Visible = false;
                    GVAnswer.HeaderRow.Cells[8].Visible = false;
                    GVAnswer.HeaderRow.Cells[10].Visible = false;
                    GVAnswer.HeaderRow.Cells[11].Visible = false;
                    //GVAnswer.Rows[i].Cells[1].Visible = false;
                    if (GVAnswer.Rows[i].Cells[4].Text == "T")
                    {
                        GVAnswer.Rows[i].Cells[4].Text = "Text";
                    }
                    else
                    {
                        GVAnswer.Rows[i].Cells[4].Text = "Image";
                    }
                    if (GVAnswer.Rows[i].Cells[5].Text == "View Image")
                    {
                        HtmlAnchor a = new HtmlAnchor();
                        a.HRef = "~/ImageHandler.aspx?ACT=AIMG&AID=" + GVAnswer.Rows[i].Cells[2].Text;
                        a.Attributes.Add("rel", "lightbox");
                        a.InnerText = GVAnswer.Rows[i].Cells[5].Text;
                        GVAnswer.Rows[i].Cells[5].Controls.Add(a);
                    }
                    if (GVAnswer.Rows[i].Cells[7].Text == "Yes")
                    {
                        j++;
                        ViewState["CheckHasMulAns"] = j;// To Chek How Many answer Of a particulaer Question Is Right
                    }
                    GVAnswer.Rows[i].Cells[8].Visible = false;
                    GVAnswer.Rows[i].Cells[3].Visible = false;
                    GVAnswer.Rows[i].Cells[10].Visible = false;
                   GVAnswer.Rows[i].Cells[6].Visible = false;
                   GVAnswer.Rows[i].Cells[11].Visible = false;
                    GVAnswer.Rows[i].Cells[2].Visible = false;
                    
                }
            }
        }
        catch (Exception ex)
        {
            string err = ex.Message;
            if (ex.InnerException != null)
            {
                err = err + " :: Inner Exception :- " + ex.InnerException.Message;
            }
            string addInfo = "Error in getting Answers :: -> ";
            ClsExceptionPublisher objPub = new ClsExceptionPublisher();
            objPub.Publish(err, addInfo);
        }
    }
